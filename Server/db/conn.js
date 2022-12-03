const mysql = require('mysql');

const conn = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'se-uwc-db'
});

module.exports = conn;