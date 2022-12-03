const conn = require('../db/conn');
const query = require('../db/query');
const bcrypt = require('bcrypt');
const crypto = require('crypto');

async function createAccount(user) {
    // initialization
    const q = "INSERT INTO employee(id, name, gender, dob, address, phone, nationality, hired_on, role, salary, username, password) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
    const hashPassword = await bcrypt.hash(user.password, 10);
    let id = crypto.randomBytes(5).toString('hex');

    // check for id duplication
    const findDuplicate = await query(conn, "SELECT id FROM employee WHERE ?", { id });
    while(findDuplicate.length){
        id = crypto.randomBytes(5).toString('hex');
        findDuplicate = await query(conn, "SELECT id FROM employee WHERE ?", { id });
    }

    // insert new account into db
    const params = [
        id, 
        user.name,
        user.gender,
        user.dob,
        user.address,
        user.phone,
        user.nationality,
        user.hired_on,
        user.role,
        user.salary,
        user.username,
        hashPassword 
    ];
    await query(conn, q, params);
}

async function getEmployeeById(id) {
    const q = "SELECT id, name, gender, dob, address, phone, nationality, hired_on, role, salary, username FROM employee WHERE ?";
    const params = { id: id };
    return await query(conn, q, params);
}

async function getEmployeeByUsername(username) {
    const q = "SELECT id, name, gender, dob, address, phone, nationality, hired_on, role, salary, username FROM employee WHERE ?";
    const params = { username: username };
    return await query(conn, q, params);
}

module.exports = {
    createAccount,
    getEmployeeById,
    getEmployeeByUsername
}