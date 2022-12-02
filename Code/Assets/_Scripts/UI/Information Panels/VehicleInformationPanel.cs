﻿using TMPro;
using UnityEngine;

public class VehicleInformationPanel : InformationPanel<VehicleData>
{
    [SerializeField] private TMP_Text vehicleCategory;
    [SerializeField] private TMP_Text plate;
    [SerializeField] private TMP_Text model;
    [SerializeField] private TMP_Text weight;
    [SerializeField] private TMP_Text capacity;
    [SerializeField] private TMP_Text fuelConsumption;

    public override void Show(VehicleData data)
    {
        base.Show(data);

        vehicleCategory.text = data.Category.ToString();
        plate.text = data.LicensePlate;
        model.text = "Model: " + data.Model;
        weight.text = "Weight: " + Mathf.CeilToInt(data.Weight) + "kgs";
        capacity.text = "Capacity: " + Mathf.CeilToInt(data.Capacity) + "kgs";
        fuelConsumption.text = "Fuel consumption: " + Mathf.CeilToInt(data.FuelConsumption) + "l/100km";
    }
}