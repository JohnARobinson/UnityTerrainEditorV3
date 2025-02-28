using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terrain_Grid_Script : MonoBehaviour
{
    public Text cellLabelPrefab;
	Canvas gridCanvas;

    public int width = 6;
	public int height = 6;

	public TileCell cellPrefab;

    TileCell[] cells;

    private void Awake() 
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        cells = new TileCell[height * width];

		for (int z = 0, i = 0; z < height; z++) 
        {
			for (int x = 0; x < width; x++) {
				CreateCell(x, z, i++);
			}
        }
    }

    void CreateCell (int x, int z, int i) 
    {
		Vector3 position;
		position.x = x * 10f;
		position.y = 0f;
		position.z = z * 10f;

		TileCell cell = cells[i] = Instantiate<TileCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;

        Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.z);
		label.text = x.ToString() + "\n" + z.ToString();
	}

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
