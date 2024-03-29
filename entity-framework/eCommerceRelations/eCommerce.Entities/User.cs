﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Entities
{
    
    /*
     * Schema:
     * [Table] = Definir o nome da tabela
     * [Column] = Definir o nome da coluna
     * [NotMapped] = Não mapear uma propriedade
     * [ForeignKey] = Definir que a propriedade é o vinculo da chave estrangeira
     * [InverseProperty] = Define a referência para cada FK vinda da mesma tabela.
     *  [DatabaseGenerated] = Definir se uma propriedade vai ou não ser gerenciada pelo banco
     *
     * DataAnnotations:
     * [Key] = Definir que a propriedade é uma PK.
     *
     * EF Core
     * [Index] = Definir/Criar Indice no banco (Unique)
     * 
     */
    
    
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public char Genre { get; set; }
        [Required]
        public string Rg { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string MotherName { get; set; }
        public char RegisterSituation { get; set; }
        public DateTimeOffset RegisterTime { get; set; }
        
        // UM PARA UM
        // permite a navegação, exemplo, User.Contact.CellPhone
        // Um usuário tem um contato, e um contato tem um Usuário
        // modelBuilder.Entity<User>().HasOne(Contact).WithOne(User);
        public Contact Contact { get; set; }
        
        // UM PARA MUITOS
        // permite a navegação, exemplo, User.DeliverAddresses[0].ZipCode
        // // modelBuilder.Entity<User>().HasMany(DeliverAddress).WithOne(User);
        public List<DeliverAddress> DeliverAddresses { get; set; } = new List<DeliverAddress>();

        // MUITOS PARA MUITOS
        // relacionamento muitos para muitos simples, SEM DADOS ADICIONAISNA TABELA, apenas o Id do Department e do User
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}