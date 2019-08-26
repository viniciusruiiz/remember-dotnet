using FluentNHibernate.Mapping;
using Remember.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Mapping
{
    public class MomentMapping : ClassMap<Moment>
    {
        public MomentMapping()
        {
            Table("TBL_MOM");
            Id(m => m.Id).Column("MOM_COD");

            Map(x => x.Description).Length(300).Column("MON_DSC");
            Map(m => m.Data).Length(999).Column("MON_FIL");
            Map(m => m.CreatedAt).Column("MON_CAT");
            Map(m => m.UpdatedAt).Column("MOM_UAT");
            References(m => m.MemoryLine).Column("MOM_MLN").Not.Nullable();
            References(m => m.CreatedBy).Column("MOM_USU").Not.Nullable();
        }
    }
}
