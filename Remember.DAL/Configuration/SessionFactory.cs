using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using Remember.DAL.Repository;
using Remember.DAL.Utils;
using System.Reflection;

namespace DAL.Utils
{
    public class SessionFactory
    {
        private static ISessionFactory session;

        private static ISessionFactory Session
        {
            get
            {
                if (session is null)
                    InitializeSessionFactory();

                return session;
            }
        }

        private static void InitializeSessionFactory()
        {
            session = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Server=localhost;Database=master;Trusted_Connection=True;")//ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
                    .ShowSql()
                    .FormatSql())
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .ExposeConfiguration(c => c.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new AuditEventListener() }))
                .ExposeConfiguration(c => c.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new AuditEventListener() }))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return Session.OpenSession();
        }
    }
}
