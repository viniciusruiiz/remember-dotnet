using Remember.Domain.Entity.Base;
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
            IsActive = true;
        }

        /// <summary>
        /// Construtor da classe usuário
        /// com parâmetros relacionados a login
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
            IsActive = true;
        }

        #endregion

        #region .: Properties :.

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public virtual string Email { get; protected set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public virtual string Password { get; protected set; }

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
        public virtual bool IsActive { get; protected set; }

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

        public virtual void Disable()
        {
            IsActive = false;
        }

        #endregion
    }
}
