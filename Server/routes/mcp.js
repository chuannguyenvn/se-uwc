const router = require('express').Router();
const mcpController = require('../controllers/mcp');

router.post('/add', mcpController.addMCP);
router.get('/:id', mcpController.getMCPById);
router.post('/', mcpController.getMCPByCoordinate);
router.put('/updateCurrent', mcpController.updateMCPCurrent);

module.exports = router;