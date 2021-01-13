using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RedSky.Domain.Entities;
using RedSky.Infrastructure.Data.EntityConfiguration;
using RedSky.Infrastructure.Data.EntityConfiguration.Conventions;
using RedSky.Infrastructure.Data.Migrations;

namespace RedSky.Infrastructure.Data.Context
{
    public class RedSkyContext : DbContext
    {
        public RedSkyContext()
            : base("NTBBcfrutuozoDBConnectionString")
        {
            //Disable initializer
            //Database.SetInitializer<BFGContext>(null);

            //Initializer with Migrations configuration.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RedSkyContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Permissao> Permissoes { get; set; }
        public virtual DbSet<ConexaoBanco> Conexoes { get; set; }
        public virtual DbSet<DBProvider> Providers { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Filial> Filiais { get; set; }
        public virtual DbSet<CertificadoDigital> CertificadosDigitais { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Demonstrativo> Demonstrativos { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        public virtual DbSet<Unidade> Unidades { get; set; }
        public virtual DbSet<Fatura> Faturas { get; set; }
        public virtual DbSet<NotaFiscal> NotasFiscais { get; set; }
        public virtual DbSet<LoteRPS> LotesRPSs { get; set; }
        public virtual DbSet<RPS> RPSs { get; set; }
        public virtual DbSet<Faturamento> Faturamentos { get; set; }

        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<RegimeTributario> RegimesTributarios { get; set; }
        public virtual DbSet<TipoBairro> TiposBairros { get; set; }
        public virtual DbSet<TipoLogradouro> TiposLogradouros { get; set; }
        public virtual DbSet<TipoRecolhimento> TiposRecolhimentos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<StatusLoteRPS> StatusLoteRPS { get; set; }

        public virtual DbSet<Negocio> Negocios { get; set; }
        public virtual DbSet<EtapaVenda> EtapasVenda { get; set; }

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Carregando as configurações para reconhecer attributes para precisão decimal.
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());


            modelBuilder.Configurations.Add(new CertificadoDigitalConfiguration());

            modelBuilder.Entity<Empresa>().HasMany(e => e.Atividades).WithMany(a => a.Empresas)
                .Map(mc =>
                {
                    mc.MapLeftKey("IdEmpresa");
                    mc.MapRightKey("IdAtividade");
                    mc.ToTable("EmpresaAtividade");
                });
        }
    }
}