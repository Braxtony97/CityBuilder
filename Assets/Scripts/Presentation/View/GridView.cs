using ApplicationLayer.Services;
using ApplicationLayer.UseCases;
using Domain.Models;
using UnityEngine;
using UnityEngine.InputSystem;
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
        private PlaceBuildingUseCase _placeBuilding;

        private void Awake() => 
            _cellsVisual = new GameObject[32, 32];

        [Inject]
        public void Construct(GridService gridService, PlaceBuildingUseCase placeBuilding)
        {
            _gridService = gridService;
            _placeBuilding =  placeBuilding;
        }

        private void Start() => 
            CreateGrid();
        
        private void Update()
        {
            HandleClick();
        }

        private void HandleClick()
        {
            if (Mouse.current == null) return;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    var go = hit.collider.gameObject;

                    if (go.name.StartsWith("Cell_"))
                    {
                        string[] data = go.name.Split('_');
                        int x = int.Parse(data[1]);
                        int y = int.Parse(data[2]);

                        TryBuild(x, y);
                    }
                }
            }
        }
        
        private void TryBuild(int x, int y)
        {
            bool success = _placeBuilding.TryPlaceBuilding(
                type: BuildingType.House,
                x: x,
                y: y
            );

            if (success)
            {
                Debug.Log($"Построено здание на ({x},{y})");
                
                _cellsVisual[x, y].GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                Debug.Log("Нельзя построить здание");
            }
        }

        private void CreateGrid()
        {
            float gridWidthSize = (_gridWidth - 1) * _spacing; 
            float gridHeightSize = (_gridHeight - 1) * _spacing;
            
            float centerX = -gridWidthSize / 2f;
            float centerZ = -gridHeightSize / 2f;
            
            for (int x = 0; x < _gridWidth; x++)
            {
                for (int y = 0; y < _gridHeight; y++)
                {
                    var cellObj = Instantiate(_cellPrefab, _gridParent);
                    cellObj.name = $"Cell_{x}_{y}";
                    
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