﻿using UnityEngine;
using System.Collections;

public class BuildingWindow : GUIBase {

    float width;
    Building selectedBuilding;

    public override void openView(object data)
    {
        selectedBuilding = data as Building;
    }

	void OnGUI()
    {
        width = Screen.width * 0.35f;
        GUILayout.BeginArea(new Rect(Screen.width - width, 0, width, Screen.height));
        GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
        if (GUILayout.Button("close", GUILayout.Width(50)))
        {
            GameManager.GetInstance.GuiManager.closeGUI(this.GetType().Name);
            if (GameManager.GetInstance.GuiManager.hasOpenView("PeopleWindow")) GameManager.GetInstance.GuiManager.closeGUI("PeopleWindow");

        }
        if (selectedBuilding.isWorkableBuilding) WorkableBuildingGUI();
        else GeneralBuildingGui();
        
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void WorkableBuildingGUI()
    {
        GeneralBuildingGui();
        WorkableBuilding building = selectedBuilding as WorkableBuilding;
        if (!building.selectedWorker)
        {
            if (GUILayout.Button("Assign person"))
            {
                GameManager.GetInstance.GuiManager.openGUI("PeopleWindow", false);
            }
        }
        else
        {
            GUILayout.Box(building.selectedWorker.name);
        }
    }

    void GeneralBuildingGui()
    {
        if (selectedBuilding.CanAffordNexPhase())
        {
            if (GUILayout.Button("Upgrade"))
            {
                selectedBuilding.UpgradeBuilding();
            }
        }
        else
        {
            GUILayout.Box("Can't afford upgrade");
        }
        GUILayout.Label("Building's health: " + selectedBuilding.buildingHealth);
    }

    public void assignWorker(Person person)
    {
        WorkableBuilding building = selectedBuilding as WorkableBuilding;
        if (building.selectedWorker)
        {
            building.selectedWorker.isAssignedToBuilding = false;
        }
        building.selectedWorker = person;
        person.isAssignedToBuilding = true;
    }
}
