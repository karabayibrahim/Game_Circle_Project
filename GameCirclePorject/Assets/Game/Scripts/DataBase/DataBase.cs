using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataSystemObject", order = 1)]

public class DataBase : ScriptableObject
{
    public List<GameObject> PlayerModels = new List<GameObject>();
    public List<PositiveObject> PositiveObjects = new List<PositiveObject>();
    public List<NegativeObject> NegativeObjects = new List<NegativeObject>();
}
