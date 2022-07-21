
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    DataManager db;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject levelsPanel;
    [Space]
    [SerializeField] Transform temasContenedor;
    [SerializeField] GameObject temaBotonPrefab;


    void Start()
    {
        db = DataManager.Instance;

        mainPanel.SetActive(true);
        levelsPanel.SetActive(false);

        Clear();
        LoadLevelList();
    }
 
    public void LoadLevelList()
    {
        int i = 0;
        foreach(ThemeAsset tema in DataManager.Instance.themesList)
        {
            GameObject buttonGO = Instantiate(temaBotonPrefab, temasContenedor);
            TemaBoton buttonScript = buttonGO.GetComponent<TemaBoton>();

            buttonScript.LoadData(i);
            i++;
        }
    }

    void Clear()
    {
        foreach(Transform child in temasContenedor)
        {
            Destroy(child.gameObject);
        }
    }

}
