using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Projet2Crowdfunding.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PayPalAccount> PayPalAccounts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }
        public DbSet<Report> Reports { get; set; }
        //public DbSet<StatisticsPlateform> StatisticsPlateforms { get; set; }
        //public DbSet<StatisticsProjet> StatisticsProjets { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        //public IEnumerable<object> Donations { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=Project2Crowdfunding");
        }

        public void InitializedDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //Instances Participant
            this.Participants.AddRange(
                new Participant
                {
                    Id = 1,
                    LastName = "Cisse",
                    FirstName = "Ada",
                    Gender = Gender.Femme,
                    PhoneNumber = "6666666666",
                    Birthdate = DateTime.Parse("2013-07-04"),
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 1,
                        StreetName = "Rue de la fleur",
                        StreetNumber = "12",
                        ZipCode = "57888",
                        City = "Toulouse",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 1,
                        Mail = "adacisse90@gmail.com",
                        Password = AccountService.EncodeMD5("aaaaa"),
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 2,
                    LastName = "Rchouk",
                    FirstName = "Sara",
                    Gender = Gender.Femme,
                    PhoneNumber = "5555555555",
                    Birthdate = DateTime.Parse("2011-03-14"),

                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 2,
                        StreetName = "Rue du presidant",
                        StreetNumber = "24",
                        ZipCode = "75007",
                        City = "Paris",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 2,
                        Mail = "sara.rchouk@gmail.com",
                        Password = AccountService.EncodeMD5("sssss"),
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 3,
                    LastName = "Perez",
                    FirstName = "Juanjo",
                    Gender = Gender.Homme,
                    PhoneNumber = "4444114444",
                    Birthdate = DateTime.Parse("1987-09-12"),

                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 3,
                        StreetName = "Calle de las rosas",
                        StreetNumber = "22",
                        ZipCode = "36611",
                        City = "Málaga",
                        Country = "Espagne"
                    },
                    Account = new Account
                    {
                        Id = 3,
                        Mail = "juanjoperez@gmail.com",
                        Password = AccountService.EncodeMD5("juanjuan"),
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 4,
                    LastName = "Dupuy",
                    FirstName = "Laura",
                    Gender = Gender.Femme,
                    PhoneNumber = "3333113333",
                    Birthdate = DateTime.Parse("1994-02-09"),
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 4,
                        StreetName = "Calle de abril",
                        StreetNumber = "7",
                        ZipCode = "84337",
                        City = "Sevilla",
                        Country = "Espagne"
                    },
                    Account = new Account
                    {
                        Id = 4,
                        Mail = "lauradupuy@gmail.com",
                        Password = AccountService.EncodeMD5("laulau"),
                        Role = "participant"
                    }
                }

            );


            //Instances Gestionnaires
            this.Administrators.AddRange(
                new Administrator
                {
                    Id = 1,
                    LastName = "Faucillon",
                    FirstName = "Matthieu",
                    PhoneNumber = "3333333333",
                    Type = AdministratorType.employee,
                    Account = new Account
                    {
                        Id = 5,
                        Mail = "matthieu.faucillion@gmail.com",
                        Password = AccountService.EncodeMD5("mmmmm"),
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 2,
                    LastName = "Equisoain",
                    FirstName = "Cristina",
                    PhoneNumber = "4444444444",
                    Type = AdministratorType.volunteer,
                    Account = new Account
                    {
                        Id = 6,
                        Mail = "cristinaequisoain@gmail.com",
                        Password = AccountService.EncodeMD5("ccccc"),
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 3,
                    LastName = "Lacroix",
                    FirstName = "Florent",
                    PhoneNumber = "3333333311",
                    Type = AdministratorType.employee,
                    Account = new Account
                    {
                        Id = 7,
                        Mail = "florentlacroix@gmail.com",
                        Password = AccountService.EncodeMD5("floflo"),
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 4,
                    LastName = "Martin",
                    FirstName = "Clara",
                    PhoneNumber = "1133333333",
                    Type = AdministratorType.volunteer,
                    Account = new Account
                    {
                        Id = 8,
                        Mail = "clara.martin@gmail.com",
                        Password = AccountService.EncodeMD5("clacla"),
                        Role = "admin"
                    }
                }
            );

            ////Instances PPs
            this.ProjectOwners.AddRange(
                new ProjectOwner
                {
                    Id = 1,
                    PhoneNumber = "0173000230",
                    Name = "Aurore Association",
                    Summary = "Accueillir et accompagner vers l’autonomie les personnes en situation de précarité ou d’exclusion via l’hébergement, les soins et l’insertion.",
                    Description = "Créée en 1871, l’association Aurore héberge,soigne et accompagne plus de 41 300 personnes en situation de précarité" +
                    " ou d’exclusion vers une insertion sociale et professionnelle." +
                    "Reconnue d’utilité publique depuis 1875, Aurore s’appuie sur son expérience pour proposer et expérimenter des formes innovantes" +
                    " de prises en charge, qui s’adaptent à l’évolution des phénomènes de précarité et d’exclusion." +
                    " L’association travaille en partenariat avec l’Etat, les collectivités locales, les régions, les départements et les communes." +
                    "Le dialogue avec les autorités qui financent les actions est permanent, en cohérence avec les besoins recensés sur " +
                    "ses territoires d'intervention. Aurore intervient principalement en Île-de-France et dans 7 autres régions (Nouvelle-Aquitaine, " +
                    "Occitanie, Centre-Val de Loire, Auvergne-Rhône-Alpes, Grand-Es,Hauts-de-France et Pays-de-la-Loire). " +
                    "Organisées autour de trois missions, hébergement" +
                    "soin et insertion," +
                    " ses activités sont multiples : maraudes, accueil et l’hébergement de personnes en situation d’addiction, activités de réinsertion sociale et professionnelle à destination de personnes en rupture d’emploi ou handicapées," +
                    " hébergement et accompagnement de femmes victimes de violences, soins de personnes en situation de précarité, hébergement et accompagnement de personnes en souffrance psychique",
                    HyperLink = "https://aurore.asso.fr",

                    VolunteerDescritpion = "Les bénévoles nous apportent du bien - être et du savoir," +
                    "ils nous soutiennent pour avancer dans notre vie.C'est l'art de la gratuité du cœur Vous avez une envie de partager," +
                    "un désir de vous engager, une compétence à faire vivre...Sans hésiter, faites nous une proposition d’activité!" +
                    "Vous avez envie d’animer un atelier photo ? du coaching ? du yoga ? " +
                    "Des exemples de ce que font les bénévoles à nos côtés : animation d’ateliers divers," +
                    "cours de français,sorties culturelles, aide au fonctionnement de l’épicerie solidaire, " +
                    "initiation à l’informatique, vestiaire, bien - être, sport, jardinage, accueil, traductions, conseil…" +
                    "Comme plus de 850 personnes, rejoignez - nous sur des missions bénévoles et devenez un acteur solidaire. S’engager bénévolement à AURORE, " +
                    "c’est se donner les moyens de l’action, auprès d’une grande association laïque.C’est agir en solidarité et avec des principes humanistes.",
                    Partnership = "Dons solidaire, Le chainon manquant, L'agence du don en nature.",

                    Type = ProjectOwnerType.Association,

                    AssociationProof = "/JustificatifsPP/proofAuroreAsso.png",

                    Image = "/ImageAssos/logoAuroreAsso.jpg",

                    Status = AssoStatus.published,
                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 5,
                        StreetNumber = "34",
                        StreetName = "Boulevard sebastopol",
                        ZipCode = "75004",
                        City = "Paris",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 9,
                        Mail = "associationaurore@gmail.com",
                        Password = AccountService.EncodeMD5("aurore"),
                        Role = "po"

                    }


                },

                new ProjectOwner
                {
                    Id = 2,
                    PhoneNumber = "0638023453",
                    Name = "WWF",
                    Summary = "Depuis 1973, le WWF France agit au quotidien afin d'offrir aux générations futures une planète vivante. Nous œuvrons pour mettre un frein à la dégradation de l'environnement et construire un avenir où les humains vivent en harmonie avec la nature." +
                        " Constituée de bénévoles, Rêv’Animal a pour but :de prendre en charge,de soigner, de stériliser, et de replacer des animaux",

                    Description = "Le Fonds Mondial pour la Nature (WWF) est l'une des toutes premières organisations indépendantes de protection de l'environnement dans le monde" +
                        ", avec un réseau actif dans plus de 100 pays et fort du soutien de près de 6 millions de membres." +
                        " Le WWF France, Fondation reconnue d'utilité publique, oeuvre pour une planète vivante depuis Paris, Marseille, les Alpes," +
                        " la Guyane et la Nouvelle-Calédonie.Le siège du WWF International − le secrétariat de l’organisation au niveau mondial − est situé à Gland en Suisse. " +
                        "Il dirige et coordonne le réseau des bureaux du WWF dans le monde entier, favorise les partenariats mondiaux et coordonne les campagnes internationales. " +
                        "La Fondation était jusqu'à la fin de l'année 2017, présidée par Yolanda Kakabadse et dirigée par Marco Lambertini. En 2018, Pavan Sukhdev, " +
                        "ancien directeur de UN Environnement a succédé à Yolanda Kakabadse. Son Altesse Royale le duc d'Édimbourg en est le Président émérite.",


                    HyperLink = "https://www.wwf.fr/",
                    VolunteerDescritpion = "Rejoignez ceux, membres et donateurs, partenaires et sympathisants, qui ont bâti avec nous une association riche aujourd’hui de 220 000" +
                        " donateurs et de milliers de bénévoles, toujours disponibles pour se mobiliser et démultiplier notre capacité d’action !Le siège du WWF International − le secrétariat de l’organisation au niveau mondial − est situé à Gland en Suisse. " +
                        "Il dirige et coordonne le réseau des bureaux du WWF dans le monde entier, favorise les partenariats mondiaux et coordonne les campagnes internationales. " +
                        "La Fondation était jusqu'à la fin de l'année 2017, présidée par Yolanda Kakabadse et dirigée par Marco Lambertini. En 2018, Pavan Sukhdev, " +
                        "ancien directeur de UN Environnement a succédé à Yolanda Kakabadse. Son Altesse Royale le duc d'Édimbourg en est le Président émérite.",

                    Partnership = "Fiat Panis, UNESCO",

                    Type = ProjectOwnerType.ONG,

                    AssociationProof = "/JustificatifsPP/proofwwf.jpeg",

                    Image = "/ImageAssos/logoWwf.jpeg",
                    Status = AssoStatus.published,
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 6,
                        StreetName = "Rue Jean Vallet",
                        StreetNumber = "3",
                        ZipCode = "59630",
                        City = "Bourbourg",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 10,
                        Mail = "ongwwf@gmail.com",
                        Password = AccountService.EncodeMD5("wwfwwf"),
                        Role = "po"
                    }

                },


                new ProjectOwner
                {
                    Id = 3,
                    PhoneNumber = "4499444444",
                    Name = "Play International",
                    Summary = "PLAY International, est née en 1999 d’une conviction profonde : le sport est à la fois un droit fondamental" +
                        " et une façon de résoudre les problématiques de nos sociétés. ",
                    Description = "Ce postulat a inspiré les premières initiatives de terrain de l’ONG dans des contextes d’urgence et de post - urgence.En Bolivie, " +
                        "au Sri Lanka ou en Afghanistan, PLAY a été confronté à la nécessité prégnante d’inventer des dispositifs d’accompagnement permettant" +
                        " à des enfants de surmonter un traumatisme ou apprendre comment se prémunir d’une maladie chronique.Lors de sa première décennie d’existence," +
                        "en intervenant auprès de plusieurs centaines de milliers de bénéficiaires,PLAY et ses partenaires ont démontré que :" +
                        "- Le sport est un langage universel permettant de mobiliser comme peu d’activités sont capable de le faire." +
                        "- Le sport et le jeu ont pleinement leurs places dans le secteur humanitaire et peuvent apporter des réponses concrètes à des problématiques sociales et sanitaires," +
                        "y compris dans les situations les plus précaires." +
                        " L’activité physique et sportive est une matière permettant de faire beaucoup avec peu,notamment lorsque l’on se focalise sur le volet pédagogique. ",
                    HyperLink = "https://www.play-international.org/",

                    VolunteerDescritpion = "DEVENIR BÉNÉVOLE PLAY International suscite votre intérêt ? Vous avez des compétences dans un domaine précis," +
                        "et vous souhaitez vous engager en faveur d’une association défendant des valeurs éducatives ? Intégrez notre communauté de bénévoles et rejoignez l’équipe! Nous recherchons essentiellement des bénévoles pour la course Vertigo et dans des domaines spécifiques tels que la photographie," +
                        "de la traduction et le graphisme. CONTACTEZ - NOUS" +
                        "REJOINDRE LE GROUPE FACEBOOK DES BÉNÉVOLES  PLAY et ses partenaires ont démontré que :" +
                        "- Le sport est un langage universel permettant de mobiliser comme peu d’activités sont capable de le faire." +
                        "- Le sport et le jeu ont pleinement leurs places dans le secteur humanitaire et peuvent apporter des réponses concrètes à des problématiques sociales et sanitaires," +
                        "y compris dans les situations les plus précaires." +
                        " L’activité physique et sportive est une matière permettant de faire beaucoup avec peu,notamment lorsque l’on se focalise sur le volet pédagogique.",

                    Partnership = "PROPARCO, ID4D, Fond francais pour l'environnement mondial ",

                    Type = ProjectOwnerType.ONG,
                    AssociationProof = "/JustificatifsPP/proofPlay.png",
                    Image = "/ImageAssos/logoPlay.png",
                    Status = AssoStatus.published,

                    Newsletter = true,
                    ConfidentialityCharter = true,

                    Address = new Address
                    {
                        Id = 7,
                        StreetName = "rue de Vaugirard",
                        StreetNumber = "173",
                        ZipCode = "75015",
                        City = "Paris",
                        Country = "France"
                    },


                    Account = new Account
                    {
                        Id = 11,
                        Mail = "playinternational@gmail.com",
                        Password = AccountService.EncodeMD5("playplay"),
                        Role = "po"
                    }

                },

                new ProjectOwner
                {
                    Id = 4,
                    PhoneNumber = "0478697979",
                    Name = "Handicap international",
                    Summary = "Handicap International vient en aide aux populations vulnérables, notamment les personnes handicapées, partout dans le monde où cela est nécessaire. L’association répond à leurs besoins essentiels et spécifiques," +
                    " améliore leurs conditions de vie et les aide à s’insérer dans la société. ",
                    Description = "Depuis plus de 35 ans, nos équipes et nos partenaires démontrent que des solutions sont possibles, en s’appuyant sur les individus, leurs familles et leurs communautés, et en prenant en compte les ressources humaines, les savoir-faire et les matériaux disponibles sur place." +
                    "L’association propose une approche globale qui vise à améliorer les conditions de vie des personnes handicapées ou vulnérables en combinant un ensemble d’actions complémentaires : soins aux blessés," +
                    "appareillage et réadaptation ; actions contre les restes explosifs de guerre; insertion scolaire ou économique; prévention des maladies invalidantes; plaidoyer pour changer les lois nationales ou les normes internationales… Notre mandat L’association intervient dans les situations de pauvreté et d’exclusion, de conflits et de catastrophes aux côtés des personnes handicapées et des populations vulnérables afin:" +
                    "d’améliorer leurs conditions de vie et de promouvoir le respect de leur dignité et de leurs droits fondamentaux " +
                    "d’agir et de témoigner, pour que leurs besoins essentiels soient correctement couverts." +
                    "Nos valeurs, notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine, nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité est le socle de notre action de solidarité.Nous considérons chaque personne sans discrimination, et reconnaissons à chacun sa dignité.Notre action est empreinte de respect, de bienveillance et d’humilité." +
                    "INCLUSION Nous promouvons l’inclusion de chacun dans la société et la participation de tous, dans le respect de la diversité, de l’équité et des choix de chacun. Nous reconnaissons la différence comme une richesse." +
                    "En savoir plus sur l'inclusion " +
                    "ENGAGEMENT Nous nous engageons avec détermination et audace, à développer des réponses adaptées, pragmatiques et innovantes. Nous agissons et mobilisons autour de nous pour combattre les injustices." +
                    "INTÉGRITÉ " +
                    "Nous agissons de manière indépendante, professionnelle, désintéressée et transparente." +
                    "Nos bénéficiaires 3969 593 bénéficiaires directs en 2022 (Personnes ayant reçu un bien ou un service au cours d’un projet mis en œuvre par HI ou ses partenaires opérationnels)" +
                    "12 975 481 bénéficiaires indirects en 2020 (Personnes bénéficiant des effets d'un bien ou d’un service reçu par un bénéficiaire direct de HI)" +
                    "Populations exposées aux risques de maladies, de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables, en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées",
                    HyperLink = "https://handicap-international.fr/fr/l-association",

                    VolunteerDescritpion = "Vous souhaitez rejoindre Handicap International ? " +
                    "Notre équipe Mobilisation est là pour répondre à vos questions, rendre votre volontariat plus simple et vivre une expérience unique !" +
                    " N'hésitez pas à la contacter par mail : agissez@france.hi.org" +
                    "Populations exposées aux risques de maladies, de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables, en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées.",

                    Partnership = "alabama, Alcure, Michelin, Airfrance",

                    Type = ProjectOwnerType.Association,
                    AssociationProof = "/JustificatifsPP/proofhandicap.png",
                    Image = "/ImageAssos/handicaplogo.png",
                    Status = AssoStatus.published,

                    Newsletter = true,
                    ConfidentialityCharter = true,

                    Address = new Address
                    {
                        Id = 8,
                        StreetName = "avenue des freres lumieres",
                        StreetNumber = "138",
                        ZipCode = "69008",
                        City = "Lyon",
                        Country = "France"
                    },


                    Account = new Account
                    {
                        Id = 12,
                        Mail = "handicapinternational@gmail.com",
                        Password = AccountService.EncodeMD5("handicap"),
                        Role = "po"
                    }

                },

                 new ProjectOwner
                 {
                     Id = 5,
                     PhoneNumber = "0198521454",
                     Name = "Association Synergie",
                     Summary = "Association Synergie vient en aide aux populations vulnérables, notamment les personnes handicapées, partout dans le monde où cela est nécessaire. L’association répond à leurs besoins essentiels et spécifiques," +
                    " améliore leurs conditions de vie et les aide à s’insérer dans la société. ",
                     Description = "Depuis plus de 35 ans, nos équipes et nos partenaires démontrent que des solutions sont possibles, en s’appuyant sur les individus, leurs familles et leurs communautés, et en prenant en compte les ressources humaines, les savoir-faire et les matériaux disponibles sur place." +
                    "L’association propose une approche globale qui vise à améliorer les conditions de vie des personnes handicapées ou vulnérables en combinant un ensemble d’actions complémentaires : soins aux blessés," +
                    "appareillage et réadaptation ; actions contre les restes explosifs de guerre; insertion scolaire ou économique; prévention des maladies invalidantes; plaidoyer pour changer les lois nationales ou les normes internationales… Notre mandat L’association intervient dans les situations de pauvreté et d’exclusion, de conflits et de catastrophes aux côtés des personnes handicapées et des populations vulnérables afin:" +
                    "d’améliorer leurs conditions de vie et de promouvoir le respect de leur dignité et de leurs droits fondamentaux " +
                    "d’agir et de témoigner, pour que leurs besoins essentiels soient correctement couverts." +
                    "Nos valeurs, notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine, nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité est le socle de notre action de solidarité.Nous considérons chaque personne sans discrimination, et reconnaissons à chacun sa dignité.Notre action est empreinte de respect, de bienveillance et d’humilité." +
                    "INCLUSION Nous promouvons l’inclusion de chacun dans la société et la participation de tous, dans le respect de la diversité, de l’équité et des choix de chacun. Nous reconnaissons la différence comme une richesse." +
                    "En savoir plus sur l'inclusion " +
                    "ENGAGEMENT Nous nous engageons avec détermination et audace, à développer des réponses adaptées, pragmatiques et innovantes. Nous agissons et mobilisons autour de nous pour combattre les injustices." +
                    "INTÉGRITÉ " +
                    "Nous agissons de manière indépendante, professionnelle, désintéressée et transparente." +
                    "Nos bénéficiaires 3969 593 bénéficiaires directs en 2022 (Personnes ayant reçu un bien ou un service au cours d’un projet mis en œuvre par HI ou ses partenaires opérationnels)" +
                    "12 975 481 bénéficiaires indirects en 2020 (Personnes bénéficiant des effets d'un bien ou d’un service reçu par un bénéficiaire direct de HI)" +
                    "Populations exposées aux risques de maladies, de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables, en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées.",
                     HyperLink = "https://associationsynergie.fr/fr/l-association",

                     VolunteerDescritpion = "Vous souhaitez rejoindre Association Synergie ? " +
                    "Notre équipe Mobilisation est là pour répondre à vos questions, rendre votre volontariat plus simple et vivre une expérience unique !" +
                    " N'hésitez pas à la contacter par mail : agissez@france.hi.org Populations exposées aux risques de maladies," +
                    "de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables," +
                    "en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées.",

                     Partnership = "BNparibas, NewYorker, Michelin, Airfrance",

                     Type = ProjectOwnerType.Association,
                     AssociationProof = "/JustificatifsPP/proofSynergieInter.png",
                     Image = "/ImageAssos/logoSynergieInter.png",
                     Status = AssoStatus.published,

                     Newsletter = true,
                     ConfidentialityCharter = true,

                     Address = new Address
                     {
                         Id = 9,
                         StreetName = "avenue des freres lumieres",
                         StreetNumber = "138",
                         ZipCode = "8547",
                         City = "Wisconscin",
                         Country = "USA"
                     },


                     Account = new Account
                     {
                         Id = 13,
                         Mail = "associationsynergie@gmail.com",
                         Password = AccountService.EncodeMD5("synergie"),
                         Role = "po"
                     }

                 },




                new ProjectOwner
                {
                    Id = 6,
                    PhoneNumber = "0821525658",
                    Name = "Bioforce",
                    Summary = "Nous sommes là pour ceux qui croient en la paix et la solidarité.Tous ceux qui sauvent des vies,partout autour du monde." +
                    "Ce sont eux que nous accompagnons à devenir des humanitaires professionnels parce que s’occuper des plus vulnérables n’est pas qu’une vocation," +
                    "c’est un vrai métier.Nous sommes Bioforce. ",
                    Description = "Nous sommes une organisation humanitaire qui intervient en préparation et en réponse aux crises issues d’un conflit, d’une catastrophe naturelle ou d’une épidémie." +
                    "Nous apportons des solutions de formation,d’accompagnement et de structuration pour permettre l’accès à une aide efficace et de qualité aux populations vulnérables." +
                    "Humanitaires d’aujourd’hui ou de demain,humanitaires qui franchissent les frontières ou qui se mobilisent dans leur pays au sein de leur communauté," +
                    "organisations internationales ou nationales présentes dans les zones de crise : en Europe,en Afrique,au Moyen - Orient," +
                    "les équipes de Bioforce leur donnent le pouvoir d’agir avec efficacité auprès des populations vulnérables en leur apportant des solutions de formation et d’accompagnement.",
                    HyperLink = "https://www.bioforce.org/bioforce/",

                    VolunteerDescritpion = "Le centre de documentation Bioforce propose un fonds documentaire spécialisé sur toutes les questions liées" +
                    "aux relations internationales,l’économie,les questions sociales et culturelles,a santé,l’environnement,l’agriculture et les technologies appropriées en Afrique,Asie," +
                    "Amérique - latine,Europe Centrale etOrientale.Le centre de documentation est membre de Ritimo,réseau des centres de documentation et" +
                    "d’information sur le développement et la solidarité internationale.Bioforce recherche pour son siège de Vénissieux(69),un ou une assistant(e) documentaliste bénévole." +
                    "Vous êtes intéressés par Les questions portant sur la solidarité,vous aimez la lecture,et vous désirez vous investir dans la vie associative ? Si vous être disponible sur un créneau de 4 heures minimum par semaine," +
                    "venez partager vos passions et rencontrer les humanitaires de demain en devenant bénévole au centre de documentation de Bioforce.Humanitaires d’aujourd’hui ou de demain," +
                    "humanitaires qui franchissent les frontières ou qui se mobilisent dans leur pays au sein de leur communauté, " +
                    "organisations internationales ou nationales présentes dans les zones de crise : en Europe,en Afrique,au Moyen - Orient," +
                    "les équipes de Bioforce leur donnent le pouvoir d’agir avec efficacité auprès des populations vulnérables en leur apportant des solutions de formation et d’accompagnement.",

                    Partnership = "Unesco, Michelin, Airfrance",

                    Type = ProjectOwnerType.ONG,
                    AssociationProof = "/JustificatifsPP/bioforceproof.png",
                    Image = "/ImageAssos/bioforcelogo.png",
                    Status = AssoStatus.registered,

                    Newsletter = true,
                    ConfidentialityCharter = true,

                    Address = new Address
                    {
                        Id = 10,
                        StreetName = "Avenue du 8 Mai 1945",
                        StreetNumber = "41",
                        ZipCode = "69200",
                        City = "Venisseux",
                        Country = "France"
                    },


                    Account = new Account
                    {
                        Id = 14,
                        Mail = "bioforce@gmail.com",
                        Password = AccountService.EncodeMD5("bioforce"),
                        Role = "po"
                    }

                },

                 new ProjectOwner
                 {
                     Id = 7,
                     PhoneNumber = "0821525658",
                     Name = "FRANCEOlympique",
                     Summary = "Le comte Jean de Beaumont (1975-1980), les Transalpins Franco Carraro (1980-1989) et Mario Pescante (2001-2006), le Belge Jacques Rogge (1989-2001) et actuellement l’Irlandais Patrick Hickey ont successivement présidé l’association." +
                     "Au fil des années," +
                     "l’ACNOE que l’on désigne aujourd’hui sous l’appellation “les Comités olympiques européens” (COE),a vu le nombre de ses membres croître," +
                     "atteignant 50 CNO régulièrement réunis à Rome,siège de l’association depuis 1989.Les Comités d’organisation des Jeux olympiques(COJO) sont des invités réguliers de ces rassemblements.Le 29 juillet 2006," +
                     "l'Assemblée générale extraordinaire tenue à Rome, élit Patrick Hickey (IRL), président, et Raffaele Pagnozzi (ITA), secrétaire général." +
                     "L’ACNOE s’est fixée pour objectifs statutaires la diffusion en Europe des idéaux olympiques définis par la Charte Olympique," +
                     "l’éducation de la jeunesse par le sport et le développement des programmes de la Solidarité Olympique ainsi que la promotion de la coopération des CNO européens par la recherche," +
                     "l’étude de sujets d’intérêts communs,l’échange d’information et la défense de positions conjointes.",
                     HyperLink = "https://international.franceolympique.com/international/",

                     VolunteerDescritpion = "Vous souhaitez rejoindre Association Franceolympique ? " +
                    "Notre équipe Mobilisation est là pour répondre à vos questions, rendre votre volontariat plus simple et vivre une expérience unique !" +
                    " N'hésitez pas à la contacter par mail : franceolympique@france.hi.org.Humanitaires d’aujourd’hui ou de demain," +
                    "humanitaires qui franchissent les frontières ou qui se mobilisent dans leur pays au sein de leur communauté," +
                    "organisations internationales ou nationales présentes dans les zones de crise : en Europe,en Afrique,au Moyen - Orient," +
                    "les équipes de Bioforce leur donnent le pouvoir d’agir avec efficacité auprès des populations vulnérables en leur apportant des solutions de formation et d’accompagnement.",

                     Partnership = "airbnb, Allianz, Athos",

                     Type = ProjectOwnerType.Association,
                     AssociationProof = "/JustificatifsPP/franceolympiqueproof.png",
                     Image = "/ImageAssos/franceolympiquelogo.png",
                     Status = AssoStatus.registered,

                     Newsletter = true,
                     ConfidentialityCharter = true,

                     Address = new Address
                     {
                         Id = 11,
                         StreetName = "avenue de France",
                         StreetNumber = "78",
                         ZipCode = "75012",
                         City = "Paris",
                         Country = "France"
                     },


                     Account = new Account
                     {
                         Id = 15,
                         Mail = "franceOlymique@gmail.com",
                         Password = AccountService.EncodeMD5("france"),
                         Role = "po"
                     }

                 },


                 new ProjectOwner
                 {
                     Id = 8,
                     PhoneNumber = "0652141213",
                     Name = "Drepacare",
                     Summary = "Fondé en 2010, l’association a pour but :De soutenir les malades atteints de maladies génétiques du globule rouge en particulier la Drépanocytose,ainsi que leur famille." +
                     "De contribuer à la diffusion des informations concernant le dépistage,le suivi et les méthodes de traitements de ces maladies De favoriser la recherche scientifique." +
                     "D’aider,de soutenir et favoriser la recherche scientifique." +
                     "De servir de trait d’union entre les malades atteints de maladies héréditaires du globule rouge,les hôpitaux et les institutions administratives.Mener des actions à l’échelle nationale et internationale.",
                     HyperLink = "https://www.drepa31.fr/",

                     VolunteerDescritpion = "Devenir membre de l’association Drepacare c’est s’engager en tant que bénévole." +
                     "L’association Drepa31est une association dirigée par des bénévoles!Vous ou un de vos proches êtes touchés par la drépanocytose ?Vous avez un talent ? Vous souhaitez le mettre à profit de notre association ?" +
                     "N’hésitez pas à nous rejoindre et adhérez à l’association Drepacare et devenir membre de l’Association DREPA31 pour une cotisation annuelle de 10€.D’aider,de soutenir et favoriser la recherche scientifique." +
                     "De servir de trait d’union entre les malades atteints de maladies héréditaires du globule rouge,les hôpitaux et les institutions administratives.Mener des actions à l’échelle nationale et internationale.",

                     Partnership = "Assurance maladie, mairie de toulouse, MCGRE",

                     Type = ProjectOwnerType.Association,
                     AssociationProof = "/JustificatifsPP/drepacareproof.png",
                     Image = "/ImageAssos/drepacarelogo.png",
                     Status = AssoStatus.published,

                     Newsletter = true,
                     ConfidentialityCharter = true,

                     Address = new Address
                     {
                         Id = 12,
                         StreetName = "place du dr joseph Baylac",
                         StreetNumber = "1",
                         ZipCode = "31300",
                         City = "Toulouse",
                         Country = "France"
                     },


                     Account = new Account
                     {
                         Id = 16,
                         Mail = "drepacare@gmail.com",
                         Password = AccountService.EncodeMD5("drepacare"),
                         Role = "po"
                     }

                 }

            );


            ////Instances Project
            this.Projects.AddRange(
                new Project
                {
                    Id = 1,
                    Status = Status.Publié,
                    Name = "Addictions-Maladies chroniques",
                    Summary = "L’accompagnement des personnes dans leurs pratiques addictives" +
                    "L’association Aurore est depuis de nombreuses années mobilisée dans l’accompagnement des personnes se trouvant en situation d’addictions :" +
                    "les professionnels mettent en place des actions de prévention," +
                    "de réduction des risques et de soins." +
                    " Les équipes pluridisciplinaires apportent des réponses adaptées prenant en compte le contexte social.",
                
                    Descritpion = "De quoi parle-t-on lorsqu’il est question d’abstinence? C’est le thème sur lequel ont phosphoré cinquante usagers et professionnels de" +
                    " quatre dispositifs d’Aurore et de deux partenaires historiques de l’association. Un débat s’est déroulé tout au long de la journée du 24 novembre 2021." +
                    " La place de l’abstinence dans le parcours de soin et de rétablissement, l’intérêt de proposer l’expérience d’une fenêtre d’abstinence, la question des " +
                    "traitements médicamenteux face aux demandes d’abstinence… loin des stéréotypes, les réflexions issues des expériences vécues et des positionnements professionnels" +
                    " ont permis des participants d’exposer différentes approches des addictions." +
                    "Etablir une réflexion commune Dans son discours d’ouverture, Florian Guyot, directeur général de l’association, précise la portée d’un tel travail :" +
                    " « C’est une journée importante, parce que se réunir pour élaborer ensemble autour de pratiques, et essayer de co - construire  de capitaliser, " +
                    "est quelque chose auquel je tiens beaucoup ». L’association Aurore, " +
                    "la société,est de plus en plus confrontées aux enjeux des addictions.De la consommation de crack dans les espaces publics aux nouvelles pratiques comme le « chemsex »," +
                    "les consommations excessives ont un impact lourd sur les consommateurs, notamment sur leur situation sociale et psychologique. ",

                    Picture = "/ImagesProject/imgProjetAurore.jpg",
                    Category = Category.Santé,
                    StartDate = new DateTime(2021, 11, 9, 16, 5, 7, 123),
                    EndDate = new DateTime(2022, 2, 24, 0, 0, 0, 0),
                    Video = "https://www.youtube.com/embed/Y_-TnjTNVFA",// "/VideosProject/VideoAurore.jpg",
                    MaterialDonation = "Médicaments, Matériaux informatiques, Bonbons pour arreter de fumer. ",
                    Location = "Iceland",
                    ProjectOwnerId = 1,
                    HeartCounter = 1
                },

                new Project
                {
                    Id = 2,
                    Status = Status.sumittedForPublishing,
                    Name = "Doubler la population mondiale de tigres",
                    Summary = "C’est sans doute la stratégie de restauration la plus ambitieuse jamais entreprise pour une seule espèce." +
                    " En 2010, alors que le nombre de tigres est au plus bas, les gouvernements des 13 pays qui abritent encore " +
                    "le félin s’engagent à multiplier sa population par deux d’ici 2022. L’initiative Tiger X 2 est lancée.",

                    Descritpion = "En tant que grand prédateur, Panthera tigris joue un rôle clé dans le maintien de la bonne santé" +
                    " de son écosystème et des services vitaux rendus par ce dernier aux autres espèces et aux populations locales :" +
                    " approvisionnement en nourriture et en eau douce, notamment. On parle d’espèce parapluie car sa protection garantit" +
                    " celle des autres espèces avec lesquelles il partage son habitat. Par sa seule présence, le félin renforce également" +
                    " l’attractivité de la zone dans laquelle il vit. Stimulant l’activité touristique, il procure des sources de revenus " +
                    "alternatives aux communautés vivant autour de son aire de répartition. Mais aujourd’hui, le félin est gravement menacé." +
                    "En danger d’extinction,l’espèce est inscrite sur la liste rouge de l'UICN. " +
                    "Recherché pour sa peau mais aussi pour diverses parties de son corps, supposées soigner plusieurs pathologies dans la médecine " +
                    "traditionnelle chinoise, Panthera tigris est victime d’un trafic international, exercé par de puissantes mafias. Si sa chasse est" +
                    " désormais interdite, en Asie, on continue de tuer le tigre pour s’approprier symboliquement sa puissance, fabriquer des médicaments" +
                    " utilisés dans la médecine traditionnelle ou encore pour en faire des articles de décoration ou des objets" +
                    " souvenirs. De 2000 à 2018, 1142 saisies de tigres ont été réalisées dans 32 pays.  ",

                    Picture = "/ImagesProject/imgWwf.jpeg",
                    Category = Category.Environnement,
                    StartDate = new DateTime(2022, 1, 29, 15, 6, 8, 245),
                    EndDate = new DateTime(2022, 7, 29, 15, 6, 8, 245),
                    Video = "https://www.youtube.com/embed/FK3dav4bA4s",///VideosProject/Videowwf.jpg",
                    MaterialDonation = "Matèriaux de constructions, Aliments pour nourrir les tigres",
                    Location = "Lille",
                    ProjectOwnerId = 2,
                    HeartCounter = 0
                },


                new Project
                {
                    Id = 3,
                    Status = Status.Publié,
                    Name = "Préserver les mangroves du Manambolo",
                    Summary = "Situées sur le littoral Ouest de l’île de Madagascar, les mangroves de la région du Manambolo sont d’une importance cruciale pour les populations locales." +
                    "Elles n’en sont pas moins menacées : leur surexploitation et le changement climatique les détériorent de manière considérable.",

                    Descritpion = "Un écosystème indispensable Les mangroves jouent un rôle essentiel dans la résilience des écosystèmes face au changement climatique et dans la stabilisation des zones côtières." +
                    "Daniel Vallauri, Chargé du programme Forêts au WWF France 60 000 hectares continus le long du littoral malgache," +
                    "les mangroves sont indispensables aux populations locales.Elles leur procurent nourriture, bois de chauffage ainsi que matériaux de construction pour leurs habitations.Elles sont aussi dotées de vertus médicinales." +
                    "Face au changement climatique et aux phénomènes naturels extrêmes, la mangrove joue également un rôle capital puisqu’elle protège l’intérieur de la côte des dégâts cycloniques et de l’érosion.Enfin,elle filtre l’eau et stocke le carbone," +
                    "comme le font les forêts terrestres. A Madagascar,les mangroves de la région du Manambolo protègent notamment la future Aire Marine Protégée de l’archipel des Îles Barren contre la sédimentation venant du versant ouest de l’île.Elles garantissent également la protection de la zone humide de Manambolomaty(classée site RAMSAR)," +
                    "de la forêt primaire de Tsimembo ainsi que des plaines rizicoles de Bemamba et de Soahany contre les effets néfastes de l’augmentation du niveau de la mer causée par le changement climatique." +
                    "C’est grâce à ces écosystèmes uniques que poissons et invertébrés migrent.",

                    Picture = "/ImagesProject/mangroveimage2.jpeg",
                    Category = Category.Environnement,
                    StartDate = new DateTime(2021, 12, 9, 15, 6, 8, 200),
                    EndDate = new DateTime(2022, 8, 9, 15, 6, 8, 200),
                    Video = "https://www.youtube.com/embed/-ennmy8Iias",//VideosProject/mangrovevideo.jpeg",
                    MaterialDonation = "Barques motorisées, ",
                    Location = "Troyes",
                    ProjectOwnerId = 2,
                    HeartCounter = 3
                },

                new Project
                {
                    Id = 4,
                    Status = Status.sumittedForPublishing,
                    Name = "EJO",

                    Summary = "Ce programme sera déployé jusqu'en 2022 au Burundi, au Kosovo, au Sénégal," +
                    " au Libéria et, dans le cadre de son incubateur, dans d'autres pays d'Afrique de l'Ouest.",

                    Descritpion = "Face aux enjeux de qualité de l’éducation et de son accès par les populations " +
                    "les plus vulnérables, PLAY propose un projet reposant sur la création et la diffusion d’un " +
                    "programme pédagogique fondé entre autre sur la Playdagogie, méthode de pédagogie active et " +
                    "participative développée par l’ONG. Ces contenus seront diffusés à travers des programmes de" +
                    " formations d’enseignants et d’animateurs sportifs recevant les kits thématiques. " +
                    "Projet déployé dans les secteurs de l’éducation formelle et informelle, il s’attachera" +
                    " à créer des passerelles entre les deux pour renforcer la continuité de la prise en charge" +
                    " éducative des enfants. Il s’agira, lorsque possible, de travailler sur l’intégration des " +
                    "méthodes socio-sportives dans les cursus de formation des enseignants et animateurs sportifs" +
                    " en collaboration étroite avec les pouvoirs publics." +
                    "RÉSULTATS ATTENDUSPlus de 80 000 enfants, dont 40 % de filles qui acquièrent une meilleure compréhension des enjeux de scolarisation," +
                    "et compétences de vie liées à l’inclusion de leurs pairs en situation de vulnérabilité." +
                    "Plus de 1000 professionnels éducatifs formés qui acquièrent des compétences permettant de déployer des séances de jeux socio - sportifs et de Playdagogie reconnues officiellement par les Ministères des Sports," +
                    "et de l’Education nationale.",

                    Picture = "/ImagesProject/Playimage.jpeg",
                    Category = Category.Education,
                    StartDate = new DateTime(2021, 9, 19, 15, 6, 8, 245),
                    EndDate = new DateTime(2022, 3, 19, 15, 6, 8, 245),
                    Video = "https://www.youtube.com/embed/unW8EgFJXN4",//"/VideosProject/PlayVideo1.html",
                    MaterialDonation = "Materiaux sportifs",
                    Location = "New York",
                    ProjectOwnerId = 3,
                    HeartCounter = 0
                },

                new Project
                {
                    Id = 5,
                    Status = Status.Publié,
                    Name = "Pour inventer aujourd'hui, les réponses humanitaires de demain...",

                    Summary = "Handicap International vient en aide aux populations vulnérables, notamment les personnes handicapées, partout dans le monde où cela est nécessaire. L’association répond à leurs besoins essentiels et spécifiques, " +
                    "améliore leurs conditions de vie et les aide à s’insérer dans la société.",

                    Descritpion = "Depuis plus de 35 ans, nos équipes et nos partenaires démontrent que des solutions sont possibles, en s’appuyant sur les individus, leurs familles et leurs communautés, et en prenant en compte les ressources humaines, les savoir-faire et les matériaux disponibles sur place." +
                    "L’association propose une approche globale qui vise à améliorer les conditions de vie des personnes handicapées ou vulnérables en combinant un ensemble d’actions complémentaires : soins aux blessés," +
                    "appareillage et réadaptation ; actions contre les restes explosifs de guerre; insertion scolaire ou économique; prévention des maladies invalidantes; plaidoyer pour changer les lois nationales ou les normes internationales… Notre mandat L’association intervient dans les situations de pauvreté et d’exclusion, de conflits et de catastrophes aux côtés des personnes handicapées et des populations vulnérables afin:" +
                    "d’améliorer leurs conditions de vie et de promouvoir le respect de leur dignité et de leurs droits fondamentaux " +
                    "d’agir et de témoigner, pour que leurs besoins essentiels soient correctement couverts." +
                    "Nos valeurs, notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine, nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité. ",

                    Picture = "/ImagesProject/handicapimage.jpeg",
                    Category = Category.Humanitaire,
                    StartDate = new DateTime(2021, 5, 10, 15, 6, 8, 245),
                    EndDate = new DateTime(2022, 3, 19, 15, 6, 8, 245),
                    Video = "https://www.youtube.com/embed/1g7tLluDQfI",//"/VideosProject/handicapvideo.html",
                    MaterialDonation = "Fauteuils roulants, Prothéses, Kits scolaires",
                    Location = "Nwagadougou",
                    ProjectOwnerId = 4,
                    HeartCounter = 1
                },



                new Project
                {
                    Id = 6,
                    Status = Status.Publié,
                    Name = "Renforcer les capacites des organisations en zone de crise",

                    Summary = "Les guerres en Syrie et en Irak ont conduit au déplacement de millions de personnes, " +
                    "au sein de ces pays comme dans les pays voisins, notamment la Jordanie, 3e pays d’accueil des réfugiés syriens." +
                    " Plus au Sud, au bord de la famine et sujet à d’importantes épidémies de choléra, le Yémen est plongé dans l’une des" +
                    " plus graves crises humanitaires au monde après cinq années de conflit. Selon les Nations Unies, en 2019, 24 millions " +
                    "de Yéménites (80% de la population) et 11,7 millions de Syriens sont en besoin d’assistance..",

                    Descritpion = "Les besoins en eau et assainissement sont considérés comme l’une des principales " +
                    "priorités de la plupart des pays de la région. Pour les seules crises en Syrie et au Yémen, plus de " +
                    "30 millions de personnes sont concernées, de nombreuses infrastructures ayant été endommagées. Mais la " +
                    "vraie limite pour intervenir efficacement tient pour une grande part au manque de personnes qualifiées et " +
                    "disponibles dans ce domaine. Rendre accessibles des programmes d’apprentissage dans cette région du monde est" +
                    " donc un enjeu majeur.Action contre la Faim et l’Université Germano-Jordanienne ont fait appel à Bioforce pour" +
                    " conduire toute la phase de préparation et de mise en œuvre d’un Master spécialisé à Amman, avec le soutien de " +
                    "l’OFDA (Office of Foreign Disaster Assistance, USA). Bioforce a entamé en novembre 2018 un vaste processus " +
                    "régional de consultation des ONG internationales présentes au Moyen-Orient, des Nations Unies, des universités " +
                    "et des ONG locales. Une phase préparatoire d’un an a ensuite permis de définir les compétences attendues des " +
                    "futurs managers humanitaires en eau, hygiène et assainissement et de dessiner un programme de formation et de" +
                    " dessine le programme pédagogique. Rentrée en septembre 2020 pour la première promotion !Action contre la Faim a souhaité" +
                    " renforcer les aptitudes et compétences de management.",


                    Picture = "/ImagesProject/bioforceimage.jpeg",
                    Category = Category.Humanitaire,
                    StartDate = new DateTime(2021, 8, 09, 20, 5, 8, 245),
                    EndDate = new DateTime(2022, 4, 19, 15, 6, 8, 245),
                    Video = "https://www.youtube.com/embed/oCUrC29eq6Y",//VideosProject/bioforcevideo.html",
                    MaterialDonation = "Fournitures scolaires",
                    Location = "Jordanie",
                    ProjectOwnerId = 5,
                    HeartCounter = 1
                },

                new Project
                {
                    Id = 7,
                    Status = Status.Publié,
                    Name = "PROGRAMME D’ACCOMPAGNEMENT INTERNATIONAL DES FÉDÉRATIONS",

                    Summary = "Le Programme d’accompagnement international des fédérations (PAIF) a pour objectif " +
                    "de rassembler différents services proposés aux fédérations en leur permettant de renforcer " +
                    "leur position dans leur environnement international propre, au service du sport français.",

                    Descritpion = "SOUTIEN FINANCIER DES ACTIONS STRATÉGIQUES DES FÉDÉRATIONS" +
                    "Un budget est consacré au soutien financier des actions internationales présentant le plus fort intérêt stratégique pour le sport français :" +
                    " Candidatures à des postes de dirigeants dans les instances sportives internationales ;• Candidatureet organisations d’événements institutionnels;" +
                    "• Déplacements institutionnels à l’étranger;• Accueil du Président de la Fédération internationale en France;" +
                    "• Création et développement d’unions francophones.ACCOMPAGNEMENT DES CANDIDATURES" +
                    "En complément du soutien financier, les fédérations peuvent solliciter le PAIF pour un accompagnement stratégique et opérationnel de leurs candidatures à des postes à responsabilité dans les instances sportives internationales et à l’organisation de grands événements sportifs." +
                    "A titre d’exemple le CNOSF a accompagné Jean-Christophe Rolland dans sa candidature au poste de Président de la Fédération internationale des sociétés " +
                    "d’aviron et la Fédération française de lutte dans l’obtention des championnats du monde 2017. " +
                    "Nos valeurs,notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine," +
                    "nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité.",

                    Picture = "/ImagesProject/olympiqueimage.jpeg",
                    Category = Category.Autre,
                    StartDate = new DateTime(2022, 1, 9, 20, 5, 8, 245),
                    EndDate = new DateTime(2022, 8, 9, 15, 6, 8, 245),
                    Video = "https://www.youtube.com/embed/b9-mxoxEcRY", // VideosProject/olympiquevideo.html,
                    MaterialDonation = "Materiaux sportifs",
                    Location = "International",
                    ProjectOwnerId = 1,
                    HeartCounter = 1
                },

                 new Project
                 {
                     Id = 8,
                     Status = Status.Publié,
                     Name = "Amélioration de la prise en charge des drépanocytaires",

                     Summary = "Amélioration du diagnostic, la prise en charge médicale et l’insertion sociale des drépanocytaires en Afrique subsaharienne et" +
                     " entreprendre un plaidoyer et une capitalisation efficace pour pérenniser l’action.",

                     Descritpion = "La drépanocytose est la première maladie génétique dans le monde. Elle affecte le sang et se traduit par des crises d’une intense douleur, une anémie et un risque accru d’infections. En Afrique subsaharienne, près de 2 % des nouveau-nés sont touchés par la maladie et 50 à 75 % d’entre eux meurent avant l’âge de cinq ans. De plus, les drépanocytaires souffrent d’exclusion en raison de l’ignorance et des préjugés liés à cette maladie." +
                     "L’enjeu est d’améliorer la prise en charge médicale et l’intégration sociale des drépanocytaire au Cameroun," +
                     "au Congo,en Côte d’Ivoire,à Madagascar et en RDC.Le programme propose de mettre en place le dépistage systématique dans près de 80 maternités partenaires," +
                     "de former le personnel de santé à la prise en charge de la maladie et d’accompagner les familles  par l’éducation thérapeutique.Une sensibilisation de la population sera également menée." +
                     "Le programme vise aussi à renforcer le réseau d’Afrique Centrale(REDAC) afin de promouvoir les échanges scientifiques et à assurer  un plaidoyer auprès des États." +
                     "ONG accompagne le développement humain et économiquedes pays où il intervient, à travers trois cœurs de métier : laformation technique et l’insertion professionnelle, l’appui aux" +
                     "petites entreprises, et l’accès des personnes vulnérables àl’éducation et à la santé avec ses partenaires pour batir un monde meilleur.",


                     Picture = "/ImagesProject/drepacareimage.jpeg",
                     Category = Category.Santé,
                     StartDate = new DateTime(2021, 12, 9, 20, 5, 8, 245),
                     EndDate = new DateTime(2022, 8, 9, 15, 6, 8, 245),
                     Video = "https://www.youtube.com/embed/qyUQP7xncpk", ///VideosProject/drepacarevideo.html",
                     MaterialDonation = "Don de sang, Don de materiaux de soins",
                     Location = "Afrique",
                     ProjectOwnerId = 4,
                     HeartCounter = 1
                 },

                 new Project
                 {
                     Id = 9,
                     Status = Status.Clôturé,
                     Name = "La vie aprés la guerre",

                     Summary = "Les guerres ont conduit au déplacement de millions de personnes, " +
                    "au sein de ces pays comme dans les pays voisins, notamment la Jordanie, 3e pays d’accueil des réfugiés syriens." +
                    " Plus au Sud, au bord de la famine et sujet à d’importantes épidémies de choléra, le Yémen est plongé dans l’une des" +
                    " plus graves crises humanitaires au monde après cinq années de conflit. Selon les Nations Unies, en 2019, 24 millions " +
                    "de Yéménites (80% de la population) et 11,7 millions de Syriens sont en besoin d’assistance..",

                     Descritpion = "Les besoins en eau et assainissement sont considérés comme l’une des principales " +
                    "priorités de la plupart des pays de la région. Pour les seules crises en Syrie et au Yémen, plus de " +
                    "30 millions de personnes sont concernées, de nombreuses infrastructures ayant été endommagées. Mais la " +
                    "vraie limite pour intervenir efficacement tient pour une grande part au manque de personnes qualifiées et " +
                    "disponibles dans ce domaine. Rendre accessibles des programmes d’apprentissage dans cette région du monde est" +
                    " donc un enjeu majeur.Action contre la Faim et l’Université Germano-Jordanienne ont fait appel à Bioforce pour" +
                    " conduire toute la phase de préparation et de mise en œuvre d’un Master spécialisé à Amman, avec le soutien de " +
                    "l’OFDA (Office of Foreign Disaster Assistance, USA). Bioforce a entamé en novembre 2018 un vaste processus " +
                    "régional de consultation des ONG internationales présentes au Moyen-Orient, des Nations Unies, des universités " +
                    "et des ONG locales. Une phase préparatoire d’un an a ensuite permis de définir les compétences attendues des " +
                    "futurs managers humanitaires en eau, hygiène et assainissement et de dessiner un programme de formation et de" +
                    " dessine le programme pédagogique. Rentrée prévue en septembre 2020 pour la première promotion !Action contre la Faim a souhaité" +
                    " renforcer les aptitudes et compétences.",


                     Picture = "/ImagesProject/guerreimage.jpg",
                     Category = Category.Santé,
                     StartDate = new DateTime(2020, 12, 9, 20, 5, 8, 245),
                     EndDate = new DateTime(2021, 8, 9, 15, 6, 8, 245),
                     Video = "/VideosProject/guerrevideo",
                     MaterialDonation = "Denrees alimentaires",
                     Location = "Monde",
                     ProjectOwnerId = 5,
                     HeartCounter = 0
                 },

                 new Project
                 {
                     Id = 10,
                     Status = Status.Clôturé,
                     Name = "Révéler le potentiel des jeunes de la France périphérique",

                     Summary = "L’association Chemins d’avenirs informe, accompagne et promeut les collégiens,lycéens et étudiants de la France périphérique.Elle agit à travers un système de parrainage et la création d’un écosystème de réussite autour de ses filleuls." +
                     "Chemins d’avenirs est la première structure à mentorer les jeunes des zones rurales et des villes petites et moyennes indépendamment de résultats scolaires ou de critères sociaux.Pour que seuls la motivation," +
                     "la curiosité et le potentiel d’un jeune fassent la différence dans son parcours et ses projets d’avenir.",

                     Descritpion = "Face aux enjeux de qualité de l’éducation et de son accès par les populations " +
                    "les plus vulnérables, PLAY propose un projet reposant sur la création et la diffusion d’un " +
                    "programme pédagogique fondé entre autre sur la Playdagogie, méthode de pédagogie active et " +
                    "participative développée par l’ONG. Ces contenus seront diffusés à travers des programmes de" +
                    " formations d’enseignants et d’animateurs sportifs recevant les kits thématiques. " +
                    "Projet déployé dans les secteurs de l’éducation formelle et informelle, il s’attachera" +
                    " à créer des passerelles entre les deux pour renforcer la continuité de la prise en charge" +
                    " éducative des enfants. Il s’agira, lorsque possible, de travailler sur l’intégration des " +
                    "méthodes socio-sportives dans les cursus de formation des enseignants et animateurs sportifs" +
                    " en collaboration étroite avec les pouvoirs publics." +
                    "RÉSULTATS ATTENDUSPlus de 80 000 enfants, dont 40 % de filles qui acquièrent une meilleure compréhension des enjeux de scolarisation," +
                    "et compétences de vie liées à l’inclusion de leurs pairs en situation de vulnérabilité." +
                    "Plus de 1000 professionnels éducatifs formés qui acquièrent des compétences permettant de déployer des séances de jeux socio - sportifs et de Playdagogie reconnues officiellement par les Ministères des Sports," +
                    "et de l’Education nationale.",

                     Picture = "/ImagesProject/avenirimage.jpg",
                     Category = Category.Education,
                     StartDate = new DateTime(2021, 6, 19, 15, 6, 8, 245),
                     EndDate = new DateTime(2021, 12, 19, 15, 6, 8, 245),
                     Video = "https://www.youtube.com/embed/K7GIIOYyp3I",///VideosProject/avenirVideo",
                     MaterialDonation = "Materiaux sportifs, kits scolaires",
                     Location = "Paris",
                     ProjectOwnerId = 3,
                     HeartCounter = 0
                 },

                 new Project
                 {
                     Id = 11,
                     Status = Status.Publié,
                     Name = "Projet Kirikou - Mini Transat 2022",

                     Summary = "Et bien cette fois ce n'est pas un petit garçon qui combat une terrible sorcière, mais presque !" +
                     "KIRIKOU est un voilier de 6m50," +
                     "un petit bateau en bois! Mais c'est aussi un projet qui est à l'initiative de l'association Léo Béroud, un jeune montagnard devenu marin. Après avoir eu la drôle d'idée d'aller naviguer en Polynésie suite à son bac," +
                     "il décide de se lancer dans un projet un peu fou : participer à la mini transatlantique!",

                     Descritpion = "KIRIKOU est un projet sur deux ans, mais il faut déjà commencer à s'équiper pour gravir cette montagne, car la route est longue jusqu'aux Antilles ! " +
                     "C'est pourquoi Kirikou besoin de vous pour : Des vêtements chauds pour que son skipper tienne la barre malgré le vent et le mauvais temps." +
                     "Des vivres! Parce que sur un bateau qui n'a pas de toilettes ni de lit, un plat chaud c'est tout ce qu'il faut ! " +
                     "La place de port à Concarneau pour que Kirikou soit à l'abri des tempêtes hivernales, ainsi que son entretien général : cordages, matériel de sécurité.. Et si on dépasse l'objectif de 6 000 € ? " +
                     "Et bien nous nous rapprocherons un peu plus du sommet!  Cela permettra de participer pour les inscriptions aux courses de qualifications ainsi que les places de port." +
                     "Car  Kirikou va sillonner les eaux Bretonnes pendant 2 ans pour être sélectionné," +
                     "prêt à traverser l'atlantique et partager des connaissances sur le territoire !" +
                     "n montagnard qui devient marin,drôle d'idée ?Je m'appelle Léo," +
                     " j'ai 22 ans.Je suis né et j'ai grandi en montagne, très loin de la mer !À trois ans, je monte sur des skis, à dix huit, je deviens pisteur-secouriste." +
                     "Proche des cimes enneigées et des parois,es aventures montagneuses m'emmènent toujours plus loin et plus haut : en escalade, en ski ou en speed riding." +
                     "Pendant longtemps," +
                     "j'évolue loin de la mer et des voiles qui la parcourent. ",

                     Picture = "/ImagesProject/kirikouimage.png",
                     Category = Category.Environnement,
                     StartDate = new DateTime(2021, 6, 19, 15, 6, 8, 245),
                     EndDate = new DateTime(2022, 12, 19, 15, 6, 8, 245),
                     Video = "https://www.youtube.com/embed/0vhgdzn1IjM",///VideosProject/kirikouVideo",
                     MaterialDonation = "Materiaux de la mer",
                     Location = "Bordeau",
                     ProjectOwnerId = 3,
                     HeartCounter = 0
                 },

                  new Project
                  {
                      Id = 12,
                      Status = Status.Publié,
                      Name = "C'est pas mes oignons",

                      Summary = "C'est pas mes oignons est un projet de commerce primeur, vrac et épicerie locale qui à pour objectif principal de vous régaler en vous proposant une sélection attentive de " +
                      "produits issus de l'agriculture biologique ou naturelle (sans utilisation de pesticides). ",

                      Descritpion = "Et bien, c'est avant tout regrouper un maximum de producteurs, transformateurs du coin qui m'ont déjà tapé dans les papilles et m'ont touché par leur éthique de production. " +
                      "Le bassin maraîcher des environs étant tellement riche, il serait tellement dommage de ne pas profiter de la fraîcheur des produits de saison !! Vous ne trouvez pas ?" +
                      "Les plantations de cacao,de bananes,d'avocats, de canne à sucre, de café et autres produits plus exotiques n'étant pas monnaie courante dans le coin,j'ai néanmoins réussi à me créer un réseau de grossistes " +
                      "locaux ayant fait la démarche de recherche de producteurs respectant l'environnement,Une surface de vente sur Plouigneau de 50 m2 proposant :" +
                      "Un beau rayon fruits et légumes(ma spécialité!) respectant la saisonnalité.Une quarantaine de références vrac proposant des légumineux,des féculents,du sucre,de la farine etc...Du cidre," +
                      "de la bière,des jus et des sirops transformés dans le coin.Des plantes aromatiques et médicinales cultivées," +
                      "séchées et conditionnées sur la commune.Du pain fait par un paysan boulanger du secteur(sa farine sera également disponible en vrac!!'humain et le produit." +
                      "Notre association de primeurs veut pousser la population a manger correctement.C'est à dire bio, frais et sans pesticides. Notre devise est de protéger nos clients en leur offrant des aliments de qualité.",

                      Picture = "/ImagesProject/oignon.png",
                      Category = Category.Autre,
                      StartDate = new DateTime(2022, 1, 11, 10, 7, 8, 245),
                      EndDate = new DateTime(2022, 12, 19, 15, 6, 8, 245),
                      Video = "https://www.youtube.com/embed/eLGf2zWMdfc",///VideosProject/oignonVideo",
                      MaterialDonation = "balances, Materiaux informatiques",
                      Location = "Porto",
                      ProjectOwnerId = 2,
                      HeartCounter = 0
                  },

                  new Project
                  {
                      Id = 13,
                      Status = Status.Publié,
                      Name = "Création d'une maison d'édition sur le deuil",

                      Summary = "La maison d'édition Résilience est créée pour donner la parole aux personnes vivants" +
                      " un deuil suite à la perte d'un proche (enfant, conjoint(e), animaux, …)Pourquoi ce projet ?En France," +
                      "il y a des mots à bannir : Mort,deuil,souffrance et pour cause! Ils font peur… " +
                      "Ces mots sont anxiogènes ou susceptibles d'engendrer de la peur. ",

                      Descritpion = "Souvent, les personnes endeuillées se retrouvent dans un silence, sans la possibilité d'expliquer leur parcours, de partager leurs émotions, ils se sentent incompris, ils vivent une forme d'exclusion de la société. Pourtant, rien de tel que d'exprimer ces émotions les plus enfouies, ce sont ces mots qui amènent à cheminer vers la résilience. " +
                      "Et si nous leur donnions la parole ? C'est l'objectif 1er de cette maison d'édition : donner la parole à ceux que l'on veut oublier par manque de mots." +
                      "Écrire peut s'avérer libérateur et est équivalent à une thérapie. Mettre des mots sur des maux parfois enfouis au plus profond de l'âme," +
                      "libère le traumatisme et les blocages que cela engendre.Les mots libèrent," +
                      "apaisent et pansent les blessures mais ils permettent de faire exister le proche disparu et l'intégrer dans un livre, permet de le rendre indélébile dans le temps : il a existé et il existe ! Le livre devient alors un outil de guérison et d'expression." +
                      "Le projet permettra d'éditer plusieurs ouvrages témoignant d'un chemin de résilience face à la disparition d'un être cher, mais nous savons aussi que la créativité peut aider à s'accomplir,à devenir soi," +
                      " c'est pour cela que nous souhaitons aussi éditer des jeux de cartes comme des oracles,  libérateurs d'émotions pour permettre aux personnes touchées de se libérer et de se sentir bien dans leur peau et dans leur tete. ",

                      Picture = "/ImagesProject/mort.jpeg",
                      Category = Category.Humanitaire,
                      StartDate = new DateTime(2022, 1, 11, 10, 7, 8, 245),
                      EndDate = new DateTime(2022, 12, 19, 15, 6, 8, 245),
                      Video = "https://www.youtube.com/embed/_v3w7l_dWkI",///VideosProject/deuilVideo",
                      MaterialDonation = "Imprimantes",
                      Location = "Toulouse",
                      ProjectOwnerId = 1,
                      HeartCounter = 0
                  },

                  new Project
                  {
                      Id = 14,
                      Status = Status.Publié,
                      Name = "Financement de l’impression d’un livret pour aider les étudiants en médecine",

                      Summary = "La question de la formation des médecins, indépendante d’autres intérêts que celui de la santé des patient.e.s, nous concerne toutes et tous." +
                      "La problématique étant complexe," +
                      "nous autres du collectif d’étudiants en médecine La Troupe du RIRE avons fait une synthèse du manuel de l’Organisation Mondiale de la Santé(OMS) Comprendre la promotion pharmaceutique et y répondre." +
                      "Issu de ce travail bénévole,ce livret d’autodéfense intellectuelle est né fin 2014  ",

                      Descritpion = "Le financement nous permettra d’imprimer 5000 livrets et de les distribuer gratuitement :" +
                      "– pour vous l’envoyer en contrepartie de vos dons– pour organiser des ateliers d’éducation populaire à l’attention des étudiant.e.s en médecine sur la question de l’indépendance(ateliers débats, projections…)" +
                      "– pour parler de cette question dans l’espace public au sein d’actions de sensibilisation– pour faire du lien avec nos enseignants(Doyen.nes, départements de médecine générale), pour participer à la mise en place d’une sensibilisation plus forte dans la formation médicale" +
                      "2500 livrets ont déjà été imprimés grâce à des dons du Formindep et du Syndicat de la Médecine Générale, mais nous avons également dû avancer des sous pour compléter." +
                      "Les fonds récoltés serviront donc au remboursement des étudiant.e.s et à l’impression et la distribution de nouveaux livrets.Qui sommes nous?Nous sommes des étudiant.e.s en médecine des facultés Paris 5 et Paris 7, réuni.e.s depuis 2013 au sein du collectif “La Troupe du RIRE” dont l’organisation est horizontale et informelle." +
                      "Ce qui nous réunit, c’est d’abord une forte volonté d’éthique dans notre formation médicale initiale, par l’éducation populaire." +
                      "En lisant à plusieurs le rapport de l’OMS promotion de l’industrie pharmaceutique et y répondre et entourés du Formin et du Syndicat de la SMG..",

                      Picture = "/ImagesProject/pharmacie1.jpg",
                      Category = Category.Humanitaire,
                      StartDate = new DateTime(2021, 1, 11, 10, 7, 8, 245),
                      EndDate = new DateTime(2022, 1, 19, 15, 6, 8, 245),
                      Video = "https://www.youtube.com/embed/gbFo5su9V8k",///VideosProject/pharmacieVideo",
                      MaterialDonation = "Imprimantes, Feuilles, Encres, ",
                      Location = "Toulouse",
                      ProjectOwnerId = 2,
                      HeartCounter = 0
                  }
            );
            this.Favorites.AddRange(
                new Favorite
                {
                    Id = 1,

                    ProjectId = 1,
                    ParticipantId = 1
                },
                new Favorite
                {
                    Id = 2,

                    ProjectId = 3,
                    ParticipantId = 1
                },
                new Favorite
                {
                    Id = 3,

                    ProjectId = 3,
                    ParticipantId = 3
                },
                new Favorite
                {
                    Id = 4,

                    ProjectId = 3,
                    ParticipantId = 4
                },
                new Favorite
                {
                    Id = 5,

                    ProjectId = 5,
                    ParticipantId = 4
                },

                new Favorite
                {
                    Id = 6,

                    ProjectId = 6,
                    ParticipantId = 3
                },

                new Favorite
                {
                    Id = 7,

                    ProjectId = 7,
                    ParticipantId = 4
                },

                new Favorite
                {
                    Id = 8,

                    ProjectId = 8,
                    ParticipantId = 4
                },

                new Favorite
                {
                    Id = 9,

                    ProjectId = 11,
                    ParticipantId = 4
                },

                 new Favorite
                 {
                     Id = 10,

                     ProjectId = 12,
                     ParticipantId = 4
                 },

                  new Favorite
                  {
                      Id = 11,

                      ProjectId = 13,
                      ParticipantId = 4
                  },
                  new Favorite
                  {
                      Id = 12,

                      ProjectId = 14,
                      ParticipantId = 4
                  }

                );
            this.Steps.AddRange(
                new Step
                {
                    Id = 1,
                    Amount = 10000,
                    Description = "Cette somme permettra de louer un local pour en faire un espace de santé pour les personnes addictives. Ca leur permettra" +
                    "de se confier à des professionnels du domaine qui mettent en place des actions de prévention",

                    ProjectId = 1
                },
                new Step
                {
                    Id = 2,
                    Amount = 17000,
                    Description = "Cette deuxième étape permettra de payer pour un premier temps " +
                    "les professionels chargés de la formation de nos futurs bénévols et nous permettra d'acheter des équipements" +
                    " nécessaires pour accompagner nos patients et les professionnels de santé.",
                    ProjectId = 1
                },
                new Step
                {
                    Id = 3,
                    Amount = 15000,
                    Description = "Ce montant va nous permettre de lancer L’initiative " +
                    "Tiger X 2 pour permettre à  l'espace de ne pas disparaitre et à se reproduire",
                    ProjectId = 2
                },
                new Step
                {
                    Id = 4,
                    Amount = 47000,
                    Description = "Cette première partie de la collecte, nous permettra d'acheter " +
                    "le matériel necéssaire pour la mise en place du processus du déminage et protèger " +
                    "la future Aire Marine de l’archipel des Îles Barren contre la sédimentation",
                    ProjectId = 3
                },
              
                new Step
                {
                    Id = 5,
                    Amount = 3000,
                    Description = "Cette collecte nous permettra d'acheter des kits thématiques pour mettre en " +
                    "place les formations d’enseignants et d’animateurs sportifs.",
                    ProjectId = 4
                },
                new Step
                {
                    Id = 6,
                    Amount = 45000,
                    Description = "Ces dons vont nous permettre d'acheter du matériel pour les handicapés et va aussi " +
                    "nous permetttre de facilité leur insertion scolaire ou professionnelle dans la vie de tous les jours ",
                    ProjectId = 5
                },
                new Step
                {
                    Id = 7,
                    Amount = 20900,
                    Description = "Ensuite, à ce deuxième statde, nous souhaitons mettre en place un centre " +
                    "de santé pour les handicapés. Ce qui leur permettra d'échanger entre eux.",
                    ProjectId = 5
                },
               
                  new Step
                  {
                      Id = 8,
                      Amount = 16000,
                      Description = "Cette collecte nous permettra de construire des locaux pour " +
                      "les réfugiés de guerre et de leur permettre de se réinsérer professionnellement et de mettre en " +
                      "place un service psychologique pour leur permettre d'évacuer et de se confier.",
                      ProjectId = 6
                  },
                 
              
                    new Step
                    {
                        Id = 9,
                        Amount = 60000,
                        Description = "Cette collecte sera consacrée au soutien financier des actions internationales présentant " +
                        "le plus fort intérêt stratégique pour le sport français." +
                        " Elle permettra d'acheter le matériel nécessaire pour les jeux olympiques. ",
                        ProjectId = 7
                    },

                    new Step
                    {
                        Id = 10,
                        Amount = 16000,
                        Description = "Pour acheter du matériel neccesaire pour les drépanocytaires et " +
                        "faire un centre de santé pour permettre la prise en charge rapide des personnes touchées. Elle permettra de rendre accessible les médicaments" +
                        " en aidant les patients à avoir des mutuelles gratuitement.",
                        ProjectId = 8
                    },
                   
                    new Step
                    {
                        Id = 11,
                        Amount = 20000,
                        Description = "Cette cagnotte va permettre d'offrir un suivi efficace aux personnes " +
                        "touchées par la guerre et leur permettre d'avoir accès à l'eau et aux aliments de premières nécessités.",
                        ProjectId = 9
                    },
                    new Step
                    {
                        Id = 12,
                        Amount = 15000,
                        Description = "Cette somme permettra de faire comprendre les enjeux " +
                        "de la scolarisation à plus de 80 000 enfants, dont 40 % de filles",
                        ProjectId = 10
                    },

                    new Step
                    {
                        Id = 13,
                        Amount = 6000,
                        Description = "Cette collecte permettra de participer pour les inscriptions aux courses de qualifications ainsi que les places de port." +
                        "car  le bateau Kirikou va sillonner les eaux Bretonnes pendant 2 ans pour être sélectionné.",
                        ProjectId = 11
                    },

                     new Step
                     {
                         Id = 14,
                         Amount = 25000,
                         Description = " Le but de cette collecte est avant tout de regrouper un maximum de producteurs" +
                         " et transformateurs en rendant accessible tous les matériaux nécessaires à la mise en place d'un projet de primeur",
                         ProjectId = 12
                     },
                     new Step
                     {
                         Id = 15,
                         Amount = 25000,
                         Description = "Pour l'achat du materiel d'impression pour pouvoir donner la parole à " +
                         "ceux qui ont des personnes à ne pas oublier. ",
                         ProjectId = 13
                     },
                     new Step
                     {
                         Id = 16,
                         Amount = 25000,
                         Description = "Le financement nous permettra d’imprimer 5000 livrets et de les distribuer gratuitement " +
                         "tout en sensibilisant les personnes interessées",
                         ProjectId = 14
                     }


                );

            this.Donations.AddRange(
                new Donation
                {
                    Id = 1,
                    Amount = 50,
                    PayDate = DateTime.Parse("2022-01-04"),
                    ParticipantId = 1,  
                    CollectionId = 1
                }
             );


            ////Instances PPs
            this.Collections.AddRange(
                new Collection
                {
                    Id = 1,
                    Amount = 300,
                    ProjectId = 1
                },
                new Collection
                {
                    Id =2,
                    Amount = 0,
                    ProjectId = 2
                },
                new Collection
                {
                    Id = 3,
                    Amount = 550,
                    ProjectId = 3
                },
                new Collection
                {
                    Id = 4,
                    Amount = 0,
                    ProjectId = 4
                },
                new Collection
                {
                    Id = 5,
                    Amount = 250,
                    ProjectId = 5
                },
                 new Collection
                 {
                     Id = 6,
                     Amount = 300,
                     ProjectId = 6
                 },
                new Collection
                {
                    Id = 7,
                    Amount = 140,
                    ProjectId = 7
                },
                new Collection
                {
                    Id = 8,
                    Amount = 350,
                    ProjectId = 8
                },
                new Collection
                {
                    Id = 9,
                    Amount = 1500,
                    ProjectId = 9
                },
                new Collection
                {
                    Id = 10,
                    Amount = 2480,
                    ProjectId = 10
                },

                new Collection
                {
                    Id = 11,
                    Amount = 1000,
                    ProjectId = 11
                },
                new Collection
                {
                    Id = 12,
                    Amount = 1500,
                    ProjectId = 12
                },
                new Collection
                {
                    Id = 13,
                    Amount = 3000,
                    ProjectId = 13
                },
                new Collection
                {
                    Id = 14,
                    Amount = 4000,
                    ProjectId = 14
                }

            );


            this.SaveChanges();
        }

         



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Administrator>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<ProjectOwner>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(u => new { u.Mail, u.Password })
                .IsUnique();

            modelBuilder.Entity<Collection>()
               .HasIndex(u => u.ProjectId)
               .IsUnique();

            modelBuilder.Entity<Favorite>()
              .HasIndex(u => new { u.ProjectId, u.ParticipantId })
              .IsUnique();

            modelBuilder.Entity<ProjectOwner>()
               .HasIndex(u => u.Name)
               .IsUnique();

        }

    }
}


