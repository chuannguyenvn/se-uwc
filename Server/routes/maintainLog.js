const router = require('express').Router();
const logController = require('../controllers/maintainLog');

router.post('/add', logController.addMaintainLog);
router.get('/:id', logController.getMaintainLogById);
router.get('/vehicle/:id', logController.getMaintainLogByVehicle);

module.exports = router;