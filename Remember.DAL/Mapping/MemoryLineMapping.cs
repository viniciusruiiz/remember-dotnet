using FluentNHibernate.Mapping;
using Remember.Domain.Entity;

namespace Remember.DAL.Mapping
{
    public class MemoryLineMapping : ClassMap<MemoryLine>
    {
        public MemoryLineMapping()
        {
            Table("TBL_MLN");
            Id(m => m.Id).Column("MLN_COD");

            Map(m => m.Name).Length(60).Column("MLN_NAM");
            Map(m => m.IsPublic).Column("MLN_PBL");
            Map(m => m.CreatedAt).Column("MLN_CAT");
            Map(m => m.UpdatedAt).Column("MLN_UAT");
            References(m => m.Host).Column("MLN_HST").Not.Nullable();
            HasManyToMany(m => m.Guests).Table("TBL_MLN_USU").Not.LazyLoad();
        }
    }
}
