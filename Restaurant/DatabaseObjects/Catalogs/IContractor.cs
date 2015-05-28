using Aramis.Attributes;
using Aramis.Core;
using Aramis.Enums;
using AramisInfrastructure.UI;

namespace Catalogs
    {
    [Catalog(Description = "Контрагенты", FieldCaptionInUI = "Контрагент", GUID = "AD1E6B8C-5537-486F-A9E8-602BD81D646A", HierarchicType = HierarchicTypes.None, ShowCodeFieldInForm = false, DescriptionSize = 100)]
    public interface IContractor : ICatalog
        {
        [DataField(Description = "Поставщик продукции", ShowInList = true)]
        bool IsSupplier { get; set; }

        [DataField(Description = "Нал")]
        bool Cash { get; set; }

        [DataField(Description = "Коэфф. бонусов", DecimalPointsNumber = 4)]
        decimal BonusIndex { get; set; }

        [DataField(Description = "Повна назва", ShowInList = false, Size = 100)]
        string FullDescription { get; set; }

        [DataField(Description = "Телефон", Size = 25)]
        string Phone { get; set; }

        [DataField(ShowInList = true)]
        ISalePoint SalePoint { get; set; }

        [DataField(Description = "Перевзвешивает при приеме", ShowInList = true)]
        bool Reweight { get; set; }
        }

    public class ContractorBehaviour : Behaviour<IContractor>
        {
        public ContractorBehaviour(IContractor item)
            : base(item)
            {
            }

        public override void InitNewBeforeShowing(IItemViewModeParameters viewModeParameters)
            {
            O.SalePoint = A.New<ISalePoint>(SalePointExtentions.GetSalePointIdForUser());
            }
        }

    public enum ContractorSelectorVars
        {
        ForCurrentUser,
        Suppliers
        }
    }
