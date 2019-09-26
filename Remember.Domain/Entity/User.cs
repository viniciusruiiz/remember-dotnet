using Remember.Domain.Enum;
using System;

namespace Remember.Domain.Entity
{
    public class User : ITimeStampable
    {
        #region .: Contructors :.

        /// <summary>
        /// Construtor da classe usuário
        /// sem parâmetros de entrada
        /// </summary>
        public User()
        {

        }

        #endregion

        #region .: Properties :.

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Identificador randômico de encriptografia de senha
        /// </summary>
        public virtual byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Senha encriptografada
        /// </summary>
        public virtual byte[] PasswordHash { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gênero do usuário
        /// </summary>
        public virtual char Gender { get; set; }

        /// <summary>
        /// Data de nascimento do usuário
        /// </summary>
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        /// Identificador de usuário ativado ou desativado
        /// </summary>
        public virtual UserSituation UserSituation { get; set; }

        /// <summary>
        /// Data de criação do usuário
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização do usuário
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }

        #endregion

        #region .: Methods :.
        public virtual void RequestEmailConfirmation()
        {
            UserSituation = UserSituation.ConfirmEmailPending;
        }

        public virtual void Active()
        {
            UserSituation = UserSituation.ConfirmEmailPending;
        }

        public virtual void Desactive()
        {
            UserSituation = UserSituation.ConfirmEmailPending;
        }
        #endregion
    }
}
