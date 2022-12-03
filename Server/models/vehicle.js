const conn = require('../db/conn');
const query = require('../db/query');

async function addVehicle(vehicle) {
    const params = [
        vehicle.id,
        vehicle.category,
        vehicle.model,
        vehicle.weight,
        vehicle.capacity,
        vehicle.fuel_consumption
    ];
    await query(conn, "INSERT INTO vehicle(id, category, model, weight, capacity, fuel_consumption) VALUES (?,?,?,?,?,?)", params);
}

async function getVehicleById(id) {
    return await query(conn, "SELECT * FROM vehicle WHERE ?", { id });
}

module.exports = {
    addVehicle,
    getVehicleById
}
