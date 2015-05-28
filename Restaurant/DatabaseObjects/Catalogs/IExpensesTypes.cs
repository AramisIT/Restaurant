using System;
using Aramis.Attributes;
using Aramis.DatabaseConnector;
using Aramis.Enums;
using Aramis.Core;
using Aramis.SystemConfigurations;
using Catalogs;

namespace Catalogs
    {
    [Catalog(Description = "Виды затрат", FieldCaptionInUI = "Вид затрат", GUID = "A8A8EF17-DF1B-4BDD-A020-1AFB0DEBFAEE", HierarchicType = HierarchicTypes.None,
        DescriptionSize = 35, ShowCodeFieldInForm = false, ShowCreationDate = true, ShowLastModifiedDate = true)]
    public interface IExpensesTypes : ICatalog
        {

        }
    }