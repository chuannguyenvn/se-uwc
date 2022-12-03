const conn = require('../db/conn');
const query = require('../db/query');

async function addTask(task) {
    // generate id and check for duplication
    let id = crypto.randomBytes(8).toString('hex');
    const findDuplicate = await query(conn, "SELECT id FROM mcp WHERE ?", { id });
    while(findDuplicate.length){
        id = crypto.randomBytes(8).toString('hex');
        findDuplicate = await query(conn, "SELECT id FROM employee WHERE ?", { id });
    }
    
    if(task.createdAt) {
        const q = "INSERT INTO task(id, employee_id, mcp_id, vehicle_id, createdAt, content, checkin, checkout) VALUES (?,?,?,?,?,?,?,?)";
        const params = [
            id,
            task.employee_id,
            task.mcp_id,
            task.vehicle_id,
            task.createdAt,
            task.content,
            task.checkin,
            task.checkout
        ];
        await query(conn, q, params);
    }
    else {
        const q = "INSERT INTO task(id, employee_id, mcp_id, vehicle_id, content, checkin, checkout) VALUES (?,?,?,?,?,?,?)";
        const params = [
            id,
            task.employee_id,
            task.mcp_id,
            task.vehicle_id,
            task.content,
            task.checkin,
            task.checkout
        ];
        await query(conn, q, params);
    }
}

async function getTaskById(id) {
    return await query(conn, "SELECT * FROM task WHERE ?", { id });
}

async function getTaskByEmployee(id) {
    return await query(conn, "SELECT * FROM task WHERE ?", { employee_id: id });
}

async function removeTaskById(id) {
    return await query(conn, "DELETE FROM task WHERE ?", { id });
}

module.exports = {
    addTask,
    getTaskById,
    getTaskByEmployee,
    removeTaskById
}