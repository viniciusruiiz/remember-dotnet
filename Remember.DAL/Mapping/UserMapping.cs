using FluentNHibernate.Mapping;
using Remember.Domain.Entity;

namespace Remember.DAL.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("TBL_USU");
            Id(m => m.Id).Column("USU_COD");

            Map(m => m.Email).Length(120).Not.Nullable().Unique().Column("USU_EML");
            Map(m => m.Password).Column("USU_PWD");
            Map(m => m.Name).Length(60).Column("USU_NAM");
            Map(m => m.Gender).Column("USU_GND"); 
            Map(m => m.BirthDate).Column("USU_BDT");
            Map(m => m.IsActive).Column("USU_ACT");
            Map(m => m.CreatedAt).Column("USU_CAT");
            Map(m => m.UpdatedAt).Column("USU_UAT");
        }
    }
}
