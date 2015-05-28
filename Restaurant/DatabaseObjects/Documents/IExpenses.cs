using Aramis.Attributes;
using Aramis.Core;
using AramisInfostructure.Core;
using Catalogs;

namespace Documents
    {
    [Document(Description = "Регистрация затрат", GUID = "0D87A0B4-C7CA-4791-B69E-C1DE32084FE9", ShowResponsibleInList = false)]
    public interface IExpenses : IDocument
        {
        [DataField(Description = "Статья затрат", ShowInList = true)]
        IExpensesArticles Article { get; set; }

        [DataField(Description = "Наличный расчет", ShowInList = false)]
        bool Cash { get; set; }

        [DataField(Description = "Сумма", DecimalPointsNumber = 2, ShowInList = true, SummaryType = SummaryTypes.Sum)]
        decimal Sum { get; set; }

        [DataField(ShowInList = true, SelectingType = ContractorSelectorVars.ForCurrentUser)]
        IContractor Contractor { get; set; }
        }

    public class ExpensesBehaviour : Behaviour<IExpenses>
        {
        public ExpensesBehaviour(IExpenses item)
            : base(item) { }

        }
    }