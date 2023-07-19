using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsSelect : MonoBehaviour {
    [SerializeField]
    private List<int> levels = new List<int>();

    [SerializeField]
    private Transform _root;
    [SerializeField]
    private Vector2 _gridSize;
    [SerializeField]
    private GameObject _buttonPrefab;

    void OpenLevel(int id) {
        SceneManager.LoadScene($"Level{id}Scene");
    }

    void CreateButton(int x, int y) {
        GameObject btn = Instantiate(_buttonPrefab, _root);
        RectTransform btnTransform = btn.GetComponent<RectTransform>();
        btnTransform.anchoredPosition = new Vector2(( btnTransform.sizeDelta.x + 10 ) * x, ( -btnTransform.sizeDelta.y - 10 ) * y);
        btn.GetComponent<Button>().onClick.AddListener(() => { OpenLevel(x + 1); });
        btn.GetComponentInChildren<TextMeshProUGUI>().text = ( ( y * 5 ) + x + 1 ).ToString();
    }

    // Start is called before the first frame update
    void Start() {
        levels.ForEach(l => CreateButton(l, 0));
    }

    // Update is called once per frame
    void Update() {

    }
}
