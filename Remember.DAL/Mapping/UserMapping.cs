using FluentNHibernate.Mapping;
using Remember.Domain.Entity;
using Remember.Domain.Enum;

namespace Remember.DAL.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("TBL_USU");
            Id(m => m.Id).Column("USU_COD");

            Map(m => m.Email).Length(120).Not.Nullable().Unique().Column("USU_EML");
            Map(m => m.PasswordHash).Column("USU_PWD");
            Map(m => m.PasswordSalt).Column("USU_SLT");
            Map(m => m.Name).Length(60).Column("USU_NAM");
            Map(m => m.Gender).Length(6).Column("USU_GND"); 
            Map(m => m.BirthDate).Column("USU_BDT");
            Map(m => m.UserSituation).Column("USU_ACT").CustomType<UserSituation>();
            Map(m => m.CreatedAt).Column("USU_CAT");
            Map(m => m.UpdatedAt).Column("USU_UAT");
        }
    }
}
