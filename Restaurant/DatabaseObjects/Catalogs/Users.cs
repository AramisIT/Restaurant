using System;
using Aramis.Attributes;
using Aramis.Core;
using Aramis.DatabaseConnector;
using Aramis.Extensions;
using AramisInfostructure.Queries;
using AramisInfrastructure.UI;
using Core;

namespace Catalogs
    {
    [Catalog(Description = "Пользователи", ShowInList = false, FieldCaptionInUI = "Пользователь", GUID = "A705F057-D476-46D6-BA96-0D6B111D1F85", AllowEnterByPattern = true, UseDescriptionSpellCheck = true)]
    public class Users : CatalogUsers
        {
        private const string WARNING_1 = @"Мобильные номера должны быть уникальными для каждого пользователя.
Введенный номер уже указан для пользователя ""{0}""!";

        #region string Email (Электронный адрес)

        [DataField(Description = "Электронный адрес", ShowInList = true)]
        public string Email
            {
            get
                {
                return z_Email;
                }
            set
                {
                if (z_Email != value)
                    {
                    z_Email = value;
                    NotifyPropertyChanged("Email");
                    }
                }
            }

        private string z_Email = "";

        #endregion

        public Users()
            : base()
            {
            }

        public bool PhoneIsNotUnique(long longMobile)
            {
            var query = DB.NewQuery("select top 1 cat.Description from Users as cat where cat.MobilePhone = @Phone and cat.Id <> @CurrentUserId");
            query.AddInputParameter("CurrentUserId", Id);
            query.AddInputParameter("Phone", longMobile);

            object result = query.SelectScalar();
            if (result == null)
                {
                return false;
                }
            else
                {
                string.Format(WARNING_1, result.ToString().Trim()).WarningBox();
                return true;
                }
            }
        }

    public class UsersBehaviour : Behaviour<Users>
        {
        public UsersBehaviour(Users item)
            : base(item) { }

        public override void InitItemBeforeShowing(IItemViewModeParameters viewModeParameters)
            {
            viewModeParameters.SetReadonlyField(O.Description);
            }
        }

    public class UsersListsGetter : FixedListsCreator<Users>
        {
        public enum UsersListsTypesEnum
            {
            StartsWithA
            }

        public override IQuery GetQuery(IFixedListsParameters parameters)
            {
            var listType = (UsersListsTypesEnum)parameters.GetSelectorId();
            switch (listType)
                {
                case UsersListsTypesEnum.StartsWithA:
                    var q = DB.NewQuery("select Description, Id from Users where len(Description)>2 order by  Description desc");
                    return q;

                default:
                    return null;
                }
            }
        }
    }
