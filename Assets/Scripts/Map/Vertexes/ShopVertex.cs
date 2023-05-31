using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShopVertex : Vertex
{
    public List<Good> goods;
    
    public override void OnArrive()
    {
        ShopManager.goods = goods;
        SceneManager.LoadScene("Shop");
    }
}