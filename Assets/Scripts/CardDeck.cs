using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private List<Material> cardFrontMaterial = new List<Material>();

    public List<Material> GetMaterials()
    {
        return cardFrontMaterial;
    }

}
