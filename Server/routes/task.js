const router = require('express').Router();
const taskController = require('../controllers/task');

router.post('/add', taskController.addTask);
router.get('/:id', taskController.getTaskById);
router.get('/employee/:id', taskController.getTaskByEmployee);
router.delete('/remove/:id', taskController.removeTaskById);

module.exports = router;