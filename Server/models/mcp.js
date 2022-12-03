const conn = require('../db/conn');
const query = require('../db/query');
const crypto = require('crypto');

async function addMCP(mcp) {
    // generate id and check for duplication
    let id = `M.${crypto.randomBytes(4).toString('hex')}`;
    const findDuplicate = await query(conn, "SELECT id FROM mcp WHERE ?", { id });
    while(findDuplicate.length){
        id = `M.${crypto.randomBytes(4).toString('hex')}`;
        findDuplicate = await query(conn, "SELECT id FROM mcp WHERE ?", { id });
    }
    
    // insert new MCP into db
    const q = "INSERT INTO mcp(id, name, address, capacity, longitude, latitude) VALUES (?,?,?,?,?,?)";
    const params = [
        id, 
        mcp.name,
        mcp.address,
        mcp.capacity,
        mcp.longitude,
        mcp.latitude
    ]
    await query(conn, q, params);
    await query(conn, "INSERT INTO mcpstatus(id, current) VALUES (?, 0)", [id]);
}

async function getMCPById(id) {
    return await query(conn, "SELECT * FROM mcp WHERE ?", { id });
}

async function getMCPByCoordinate(latitude, longitude) {
    return await query(conn, "SELECT * FROM mcp WHERE ?", { longitude, latitude });
}

async function updateMCPCurrent(id, current) {
    await query(conn, "UPDATE mcpstatus SET current = ? WHERE id = ?", [current, id]);
}

module.exports = {
    addMCP,
    getMCPById,
    getMCPByCoordinate,
    updateMCPCurrent
}