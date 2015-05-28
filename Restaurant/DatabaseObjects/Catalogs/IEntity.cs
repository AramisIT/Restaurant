using System;
using Aramis.Attributes;
using Aramis.DatabaseConnector;
using Aramis.Enums;
using Aramis.Core;
using Aramis.Platform;
using Aramis.SystemConfigurations;
using Catalogs;

namespace Catalogs
    {
    [Catalog(Description = "Юридические лица", FieldCaptionInUI = "Юр. лицо", GUID = "A00E7C33-6ABE-45B8-8B70-54A657877DA2", DescriptionSize = 35, HierarchicType = HierarchicTypes.None, ShowCodeFieldInForm = false, ShowCreationDate = true, ShowLastModifiedDate = true)]
    public interface IEntity : ICatalog
        {
        }

    public class EntityBehaviour : Behaviour<IEntity>
        {
        public EntityBehaviour(IEntity item)
            : base(item) { }

        public static long GetIdForCurrentUser()
            {
            long userId = SystemAramis.CurrentUserId;

            if (userId == 0) return 0;

            return A.Query(@"declare @salePoint bigint = isnull((
select MAX(IdDoc) SalePoint
	from SubSalePointSettings s
	join SalePoint cap on cap.Id = s.IdDoc and cap.MarkForDeleting = 0
	where s.[User] = @userId
	having MAX(IdDoc) = MIN(IdDoc)),0);
	
select Entity from SalePoint where Id = @salePoint", new { userId }).SelectInt64();
            }
        }
    }