using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Implementations
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
      
        [Column("Id")]
        public virtual int Id { get; set; }

    }
}
