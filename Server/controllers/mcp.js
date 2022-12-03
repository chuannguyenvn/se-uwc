const MCP = require('../models/mcp');

async function addMCP(req, res) {
    try{
        const mcp = req.body;
        await MCP.addMCP(mcp);
        res.status(201).send("MCP added successfully");
    } catch(err) {
        console.log(err);
        res.sendStatus(500);
    }
}

async function getMCPById(req, res) {
    try {
        const result = await MCP.getMCPById(req.params.id);
        if(result.length == 0) res.status(404).send("MCP not found");
        res.send(result);        
    } catch(err) {
        console.log(err);
        res.sendStatus(500);
    }
}

async function getMCPByCoordinate(req, res) {
    try {
        const result = await MCP.getMCPByCoordinate(req.body.latitude, req.body.longitude);
        if(result.length == 0) res.status(404).send("MCP not found");
        res.send(result);        
    } catch(err) {
        console.log(err);
        res.sendStatus(500);
    }
}

async function updateMCPCurrent(req, res) {
    try {
        await MCP.updateMCPCurrent(req.body.id, req.body.current);
        res.status(200).send("MCP current status updated");
    } catch(err) {
        console.log(err);
        res.sendStatus(500);
    }
}

module.exports = {
    addMCP,
    getMCPById,
    getMCPByCoordinate,
    updateMCPCurrent
}