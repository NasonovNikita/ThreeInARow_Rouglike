using System.Collections.Generic;
using Map;
using Map.Vertexes;
using UnityEngine.SceneManagement;

public class ShopVertex : Vertex
{
    public List<Good> goods;

    protected override void OnArrive()
    {
        ShopManager.goods = goods;
        SceneManager.LoadScene("Shop");
    }
}