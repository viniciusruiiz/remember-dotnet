using System;

namespace Remember.Domain.Entity
{
    public class Moment : ITimeStampable
    {
        #region .: Contructors :.

        /// <summary>
        /// Construtor da classe momento
        /// Sem parâmetros de entrada
        /// </summary>
        public Moment() {  }

        /// <summary>
        /// Construtor da classe momento
        /// com parâmetros de entrada de identificador
        /// </summary>
        /// <param name="id"></param>
        public Moment(Guid id)
        {
            Id = id;
        }

        #endregion

        #region .: Properties :.

        /// <summary>
        /// Identificador do momemnto
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Descrição do momento
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Memory line associada ao momento
        /// </summary>
        public virtual MemoryLine MemoryLine { get; set; }

        /// <summary>
        /// Usuario que criou a memória
        /// </summary>
        public virtual User CreatedBy { get; set; }

        /// <summary>
        /// Arquivo/texto associado ao momento
        /// </summary>
        public virtual string Data { get; set; }

        /// <summary>
        /// Data de criação do momento
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização do momento
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }

        #endregion
    }
}
