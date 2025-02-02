using UnityEngine;

public class Managers : MonoBehaviour
{
    static bool Initialized { get; set; } = false;

    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    readonly GameManager _game = new GameManager();
    
    public static GameManager Game { get { return Instance?._game; } }
    
    static void Init()
    {
        if (s_instance != null || Initialized != false)
            return;
        
        Initialized = true;
        var go = GameObject.Find("@Managers");
        
        if (go == null)
        {
            go = new GameObject { name = "@Managers" };
            go.AddComponent<Managers>();
        }

        DontDestroyOnLoad(go);

        // 초기화
        s_instance = go.GetComponent<Managers>();
    }
}
