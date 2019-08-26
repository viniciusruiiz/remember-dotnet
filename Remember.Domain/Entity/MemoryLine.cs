using Remember.Domain.Entity.Base;
using System;
using System.Collections.Generic;

namespace Remember.Domain.Entity
{
    public class MemoryLine : ITimeStampable
    {
        #region .: Contructors :.

        /// <summary>
        /// Construtor da classe memory line
        /// sem parâmetros de entrada
        /// </summary>
        public MemoryLine() { }

        /// <summary>
        /// Construtor da classe memory line
        /// com parâmetros de entrada de identificador
        /// </summary>
        /// <param name="id"></param>
        public MemoryLine(Guid id)
        {
            Id = id;
        }

        #endregion

        #region .: Properties :.

        /// <summary>
        /// Identificador da memory line
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Nome da memory line
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Usuário dono da memory line
        /// </summary>
        public virtual User Host { get; set; }

        /// <summary>
        /// Usuários que foram convidados a participar da memory line
        /// </summary>
        public virtual IList<User> Guests { get; set; }

        /// <summary>
        /// Identificador de memory line compartilhada ou privada
        /// </summary>
        public virtual bool IsPublic { get; set; }

        /// <summary>
        /// Data de criação da memory line
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da ultima atualização da memory line
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }

        #endregion
    }
}
