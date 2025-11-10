using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    
    public List<KitchenObjectSO> kitcchenObjectSOList;
    public string recipeName;
}
