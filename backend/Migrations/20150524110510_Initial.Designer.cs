using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using VoteApp.DAL;

namespace backend.Migrations
{
    [ContextType(typeof(ApplicationDbContext))]
    partial class Initial
    {
        public override string Id
        {
            get { return "20150524110510_Initial"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("VoteApp.DAL.Option", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Title")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("VoteCount")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("VotingId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                    });
                
                builder.Entity("VoteApp.DAL.Voting", b =>
                    {
                        b.Property<bool>("Active")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Title")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}
