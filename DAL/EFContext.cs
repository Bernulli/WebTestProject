namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        // Your context has been configured to use a 'EFContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.EFContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EFContext' 
        // connection string in the application configuration file.
        public EFContext()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<FileInfoData> FileInfoDatas { get; set; }
    }
    [Table("tblFileInfoData")]
    public class FileInfoData
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Word { get; set; }
        public int CountWords { get; set; }
        [Required, StringLength(maximumLength: 4000)]
        public string ReverseWordText { get; set; }
        [Required, StringLength(maximumLength: 4000)]
        public string OriginText { get; set; }
    }
}