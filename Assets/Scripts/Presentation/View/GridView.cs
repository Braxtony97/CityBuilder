using ApplicationLayer.Services;
using UnityEngine;
using VContainer;

namespace Presentation.View
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Transform _gridParent;
        
        [SerializeField] private float _spacing = 1.1f;
        [SerializeField] private int _gridWidth = 8;
        [SerializeField] private int _gridHeight= 8;

        private GridService _gridService;
        private GameObject[,] _cellsVisual;
        
        private void Awake() => 
            _cellsVisual = new GameObject[32, 32];

        [Inject]
        public void Construct(GridService gridService) => 
            _gridService = gridService;

        private void Start() => 
            CreateGrid();

        private void CreateGrid()
        {
            // Размер сетки по каждой оси
            float gridWidthSize = (_gridWidth - 1) * _spacing;  // Расстояние от первой до последней ячейки
            float gridHeightSize = (_gridHeight - 1) * _spacing;
            
            // Центр сетки (середина между крайними ячейками)
            float centerX = -gridWidthSize / 2f;
            float centerZ = -gridHeightSize / 2f;
            
            for (int x = 0; x < _gridWidth; x++)
            {
                for (int y = 0; y < _gridHeight; y++)
                {
                    var cellObj = Instantiate(_cellPrefab, _gridParent);
                    cellObj.name = $"Cell_{x}_{y}";
                    
                    // Позиция с центрированием
                    float posX = centerX + (x * _spacing);
                    float posZ = centerZ + (y * _spacing);
                    cellObj.transform.position = new Vector3(posX, 0, posZ); 
                    
                    _cellsVisual[x, y] = cellObj;
                }
            }
        }
        
        public void HighlightCell(int x, int y, bool canPlace)
        {
            var renderer = _cellsVisual[x, y].GetComponent<Renderer>();
            renderer.material.color = canPlace ? Color.green : Color.red;
        }
    }
}