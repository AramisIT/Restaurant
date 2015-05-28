using System;
using Aramis.Attributes;
using Aramis.DatabaseConnector;
using Aramis.Enums;
using Aramis.Core;
using Aramis.SystemConfigurations;
using Catalogs;

namespace Catalogs
    {
    [Catalog(Description = "Статьи затрат", GUID = "A6789F99-94A0-488C-96FE-CA508DF44AC5", HierarchicType = HierarchicTypes.None,
        DescriptionSize = 35, ShowCodeFieldInForm = false, ShowCreationDate = true, ShowLastModifiedDate = true)]
    public interface IExpensesArticles : ICatalog
        {
        [DataField(ShowInList = true)]
        IExpensesTypes ExpensesType { get; set; }
        }
    }