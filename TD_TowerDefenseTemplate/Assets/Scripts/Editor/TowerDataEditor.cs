using UnityEditor;

[CustomEditor(typeof(TowerData))]
public class TowerDataEditor : Editor
{
    
    TowerData comp;
    SerializedObject towerSO;
    SerializedProperty towerName;
    SerializedProperty cost;
    SerializedProperty sellCost;
    SerializedProperty range;
    SerializedProperty fireRate;
    SerializedProperty turnSpeed;
    SerializedProperty enemyTag;
    SerializedProperty ammoPrefab;
    SerializedProperty canUpgrade;
    SerializedProperty upgradeCost;
    SerializedProperty towerDataUpgrade;
    SerializedProperty towerPrefabUpgrade;


    private void OnEnable()
    {
        comp = (TowerData)target;
        towerSO = new SerializedObject(comp);
        towerName = towerSO.FindProperty("towerName");
        cost = towerSO.FindProperty("cost");
        sellCost = towerSO.FindProperty("sellCost");
        range = towerSO.FindProperty("range");
        fireRate = towerSO.FindProperty("fireRate");
        turnSpeed = towerSO.FindProperty("turnSpeed");
        enemyTag = towerSO.FindProperty("enemyTag");
        ammoPrefab = towerSO.FindProperty("ammoPrefab");
        canUpgrade = towerSO.FindProperty("canUpgrade");
        upgradeCost = towerSO.FindProperty("upgradeCost");
        towerDataUpgrade = towerSO.FindProperty("towerDataUpgrade");
        towerPrefabUpgrade = towerSO.FindProperty("towerPrefabUpgrade");
    }

    public override void OnInspectorGUI()
    {
        towerSO.Update();
        EditorGUILayout.PropertyField(towerName);
        EditorGUILayout.PropertyField(cost);
        EditorGUILayout.PropertyField(sellCost);
        EditorGUILayout.PropertyField(range);
        EditorGUILayout.PropertyField(fireRate);
        EditorGUILayout.PropertyField(turnSpeed);
        EditorGUILayout.PropertyField(enemyTag);

        EditorGUILayout.PropertyField(ammoPrefab);

        EditorGUILayout.PropertyField(canUpgrade);
        bool fold = EditorGUILayout.Foldout(canUpgrade.boolValue, "Upgrade Data");
        if (fold)
        {
            EditorGUILayout.PropertyField(upgradeCost);
            EditorGUILayout.PropertyField(towerDataUpgrade);
            EditorGUILayout.PropertyField(towerPrefabUpgrade);
        }

        EditorUtility.SetDirty(comp);
        towerSO.ApplyModifiedProperties();
    }
}
