using PriceCalculator.BLL.Constants;
using PriceCalculator.BLL.Service;
using PriceCalculator.Windows.ViewModels.Maps;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PriceCalculator.Windows.ViewModels
{
    public class CalculationViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly MaterialService materialService;
        private readonly ThicknessService thicknessService;
        private readonly PieceService pieceService;
        private readonly CalculationService calculationService;

        public CalculationViewModel()
        {
            // Initialize services
            materialService = new MaterialService(Constants.LocalDBPath);
            thicknessService = new ThicknessService(Constants.LocalDBPath);
            pieceService = new PieceService(Constants.LocalDBPath);
            calculationService = new CalculationService(Constants.LocalDBPath);

            length = 0;
            width = 0;
            selectedPiece = new PieceViewModel();
            selectedMaterial = new MaterialViewModel();
            selectedThickness = new ThicknessViewModel();
            pieces = new ObservableCollection<PieceViewModel>();
            thicknesses = new ObservableCollection<ThicknessViewModel>();
            materials = new ObservableCollection<MaterialViewModel>();


            // Initialize model lists
            setViewModels();
        }

        private async void setViewModels()
        {
            // Set Materials
            var materialViewModels = MaterialMap.MapToViewModelList(await materialService.GetMaterialsAsync());
            this.Materials = materialViewModels;
            this.SelectedMaterial = materialViewModels[0];

            // Set Pieces
            var pieceViewModels = PieceMap.MapToViewModelList(await pieceService.GetPiecesAsync());
            this.Pieces = pieceViewModels;
            this.SelectedPiece = pieceViewModels[0];
        }

        // Set Thicknesses based on SelectedMaterial values
        private async Task setThicknessesBySelectedMaterial()
        {
            var thicknessViewModels = ThicknessMap.MapToViewModelList(await thicknessService.GetThicknessesAsync());

            foreach (PropertyInfo property in this.selectedMaterial.GetType().GetProperties())
            {
                if (property.Name.Contains("CM") && (decimal)property.GetValue(this.selectedMaterial, null) == 0)
                {
                    switch (property.Name)
                    {
                        case "TwoCM":
                            thicknessViewModels.Remove(thicknessViewModels.Where(t => t.Value == 2).FirstOrDefault());
                            break;
                        case "ThreeCM":
                            thicknessViewModels.Remove(thicknessViewModels.Where(t => t.Value == 3).FirstOrDefault());
                            break;
                        case "FiveCM":
                            thicknessViewModels.Remove(thicknessViewModels.Where(t => t.Value == 5).FirstOrDefault());
                            break;
                        case "EightCM":
                            thicknessViewModels.Remove(thicknessViewModels.Where(t => t.Value == 8).FirstOrDefault());
                            break;
                        case "NineCM":
                            thicknessViewModels.Remove(thicknessViewModels.Where(t => t.Value == 9).FirstOrDefault());
                            break;
                        case "TenCM":
                            thicknessViewModels.Remove(thicknessViewModels.Where(t => t.Value == 10).FirstOrDefault());
                            break;
                        default:
                            break;
                    }
                }
            }

            this.Thicknesses = thicknessViewModels;
            this.SelectedThickness = thicknessViewModels[0];
        }

        private ushort length;
        public ushort Length
        {
            get { return length; }
            set
            {
                if (length != value)
                {
                    length = value;
                    OnPropertyChanged("Length");
                }
            }
        }

        private ushort width;
        public ushort Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        private float squareMeter;
        public float SquareMeter
        {
            get
            {
                squareMeter = ((float)length * (float)width * (float)selectedPiece.Value) / (float)10000;
                return squareMeter;
            }
        }

        private decimal squareMeterPrice;
        public decimal SquareMeterPrice
        {
            get { return getSelectedPriceByThickness(); }
            set
            {
                if (squareMeterPrice != value)
                {
                    squareMeterPrice = value;
                    OnPropertyChanged("SquareMeterPrice");
                }
            }
        }

        private decimal calculatedPriceNet;
        public decimal CalculatedPriceNet
        {
            get
            {
                double multiplier = (selectedThickness.Value > 4) ? 1.3 : 1.4;
                calculatedPriceNet = (decimal)multiplier * getSelectedPriceByThickness() * (decimal)SquareMeter;

                return calculatedPriceNet;
            }
            set
            {
                if (calculatedPriceNet != value)
                {
                    calculatedPriceNet = value;
                    OnPropertyChanged("CalculatedPriceNet");
                }
            }
        }

        private decimal calculatedPriceGross;
        public decimal CalculatedPriceGross
        {
            get
            {
                return calculatedPriceNet * (decimal)1.27;
            }
            set
            {
                if (calculatedPriceGross != value)
                {
                    calculatedPriceGross = value;
                    OnPropertyChanged("CalculatedPriceGross");
                }
            }
        }

        private decimal getSelectedPriceByThickness()
        {
            switch (selectedThickness.Value)
            {
                case 2:
                    return selectedMaterial.TwoCM;
                case 3:
                    return selectedMaterial.ThreeCM;
                case 5:
                    return selectedMaterial.FiveCM;
                case 8:
                    return selectedMaterial.EightCM;
                case 9:
                    return selectedMaterial.NineCM;
                case 10:
                    return selectedMaterial.TenCM;
                default:
                    return 0;
            }
        }


        private PieceViewModel selectedPiece;
        public PieceViewModel SelectedPiece
        {
            get { return selectedPiece; }
            set
            {
                if (selectedPiece != value)
                {
                    selectedPiece = value;
                    OnPropertyChanged("SelectedPiece");
                }
            }
        }

        private ObservableCollection<PieceViewModel> pieces;
        public ObservableCollection<PieceViewModel> Pieces
        {
            get { return pieces; }
            set
            {
                if (pieces != value)
                {
                    pieces = value;
                    OnPropertyChanged("Pieces");
                }
            }
        }

        private ThicknessViewModel selectedThickness;
        public ThicknessViewModel SelectedThickness
        {
            get { return selectedThickness; }
            set
            {
                if (selectedThickness != value)
                {
                    selectedThickness = value;
                    OnPropertyChanged("SelectedThickness");
                }
            }
        }

        private ObservableCollection<ThicknessViewModel> thicknesses;
        public ObservableCollection<ThicknessViewModel> Thicknesses
        {
            get { return thicknesses; }
            set
            {
                if (thicknesses != value)
                {
                    thicknesses = value;
                    OnPropertyChanged("Thicknesses");
                }
            }
        }

        private MaterialViewModel selectedMaterial;
        public MaterialViewModel SelectedMaterial
        {
            get { return selectedMaterial; }
            set
            {
                if (selectedMaterial != value)
                {
                    selectedMaterial = value;

                    setThicknessesBySelectedMaterial();
                    OnPropertyChanged("SelectedMaterial");
                }
            }
        }

        private ObservableCollection<MaterialViewModel> materials;
        public ObservableCollection<MaterialViewModel> Materials
        {
            get { return materials; }
            set
            {
                if (materials != value)
                {
                    materials = value;
                    OnPropertyChanged("Materials");
                }
            }
        }

        private BaseCalculationViewModel baseCalculation;
        public BaseCalculationViewModel BaseCalculation
        {
            get { return baseCalculation; }
            set
            {
                if (baseCalculation != value)
                {
                    baseCalculation = value;
                    OnPropertyChanged("BaseCalculation");
                }
            }
        }


        // Validation
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Length")
                {
                    return (this.length <= 0) ? "Nagyobbnak kell lennie, mint 0" : null;
                }
                if (columnName == "Width")
                {
                    return (this.width <= 0) ? "Nagyobbnak kell lennie, mint 0" : null;
                }
                if (columnName == "SelectedPiece")
                {
                    return (this.selectedPiece == null || this.selectedPiece.Id <= 0) ? "Válassz darabot" : null;
                }
                if (columnName == "SelectedThickness")
                {
                    return (this.selectedThickness == null || this.selectedThickness.Id <= 0) ? "Válassz vastagságot" : null;
                }
                if (columnName == "SelectedMaterial")
                {
                    return (this.selectedMaterial == null || this.selectedMaterial.Id <= 0) ? "Válassz anyagot" : null;
                }
                return null;
            }
        }
    }
}
