const router = require('express').Router();
const settingController = require('../controllers/setting');

router.post('/add', settingController.addSetting);
router.get('/:id', settingController.getSettingByUser);
router.put('/:id', settingController.updateSetting);

module.exports = router;