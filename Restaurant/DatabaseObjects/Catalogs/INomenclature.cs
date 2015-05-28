using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Aramis.Attributes;
using Aramis.DatabaseConnector;
using Aramis.Enums;
using Aramis.Core;
using Aramis.Extensions;
using Aramis.SystemConfigurations;
using AramisInfostructure.Queries;
using Catalogs;
using Core;
using AramisInfostructure.Core;

namespace Catalogs
    {
    [Catalog(Description = "Номенклатура", GUID = "ABD838DF-4EF2-4DFE-B4E9-C87F144AD739", HierarchicType = HierarchicTypes.None,
        DescriptionSize = 100, ShowCodeFieldInForm = false, ShowCreationDate = true, ShowLastModifiedDate = true)]
    public interface INomenclature : ICatalog
        {
        [DataField(Description = "Основная продукция", ShowInList = true, SelectingType = NomenclatureSelectorVars.ForSelling)]
        INomenclature MainWare { get; set; }

        [DataField(ShowInForm = false)]
        long ExternalId { get; set; }

        [DataField(Description = "Вид номенклатуры")]
        NomenclatureTypes Type { get; set; }

        [DataField(Description = "Тара для этой продукции")]
        Table<ITareRow> Tare { get; }
        }

    public interface ITareRow : ITableRow
        {
        [DataField(Description = "Тара", SelectingType = NomenclatureSelectorVars.Tare)]
        Ref<INomenclature> Nomenclature { get; set; }

        [DataField(Description = "Вес продажи", DecimalPointsNumber = 1)]
        decimal SellingWeight { get; set; }
        }

    public class NomenclatureBehaviour : Behaviour<INomenclature>
        {
        public NomenclatureBehaviour(INomenclature item)
            : base(item) { }

        /// <summary>
        /// Update weight for nomenclature
        /// </summary>
        /// <param name="weight">tare weight in gramms</param>
        public void UpdateTareWeight(int weight)
            {
            O.Type = NomenclatureTypes.Tare;
            var currentWeight = GetCurrentTareWeight();
            if (currentWeight == weight) return;

            var weightPos = O.Description.LastIndexOf(": ");

            O.Description = string.Format("{0}: {1}г",
                (weightPos > 0) ? O.Description.Substring(0, weightPos) : O.Description, weight);
            }

        public int GetCurrentTareWeight()
            {
            const string separator = ": ";
            var weightPos = O.Description.LastIndexOf(separator);
            if (weightPos > 0)
                {
                var weightStr = O.Description.Substring(weightPos + separator.Length);
                if (weightStr.EndsWith("г", StringComparison.InvariantCultureIgnoreCase))
                    {
                    weightStr = weightStr.Substring(0, weightStr.Length - 1);
                    }

                return (int)weightStr.ToInt64(true);
                }

            return 0;
            }

        public void CheckTare(Dictionary<long, decimal> tareInfoDictionary)
            {
            foreach (var row in O.Tare)
                {
                decimal sellingWeight;
                if (tareInfoDictionary.TryGetValue(row.Nomenclature.Id, out sellingWeight))
                    {
                    row.SellingWeight = sellingWeight;
                    tareInfoDictionary.Remove(row.Nomenclature.Id);
                    }
                }

            foreach (var tareKvp in tareInfoDictionary)
                {
                var newRow = O.Tare.Add();
                newRow.Nomenclature.Id = tareKvp.Key;
                newRow.SellingWeight = tareKvp.Value;
                }
            }
        }

    public enum NomenclatureTypes
        {
        [DataField(Description = "Продукция")]
        Product,

        [DataField(Description = "Тара")]
        Tare
        }

    public enum NomenclatureSelectorVars
        {
        CustomActiveOnly,
        ForSelling,
        Tare
        }
    }