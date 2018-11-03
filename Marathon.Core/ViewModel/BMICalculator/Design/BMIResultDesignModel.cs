﻿using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.BMICalculator.Design
{
    /// <summary>
    /// The design-time data for a <see cref="BMIResultViewModel"/>
    /// </summary>
    public class BMIResultDesignModel : BMIResultViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BMIResultDesignModel Instance => new BMIResultDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BMIResultDesignModel()
        {
            Value = 24.2;
            Description = "Здоровый";
            Image = DesignModelHelpers.StringToByteArray("89504e470d0a1a0a0000000d49484452000001840000023c0806000000f1ccdc56000000017352474200aece1ce90000000467414d410000b18f0bfc6105000000097048597300000dd700000dd70142289b7800001c3049444154785eeddd7bc87d577de7f1682e46a326315e63bc546daaf53ad6716aa7de502b6aad28512b5e8a838c8a23eda06244893252a9b428164589286218118b3894c86010898858442245a428454444141109221242683f0b1b14bbcc6f9ff59cb3cfdadfe7f582f77ffd3dbf48d7d99fdf732efb9c05859d9f2e4dff2dbd22bd2b5d9dfe5ffaa7f4bdf49df4a5f40fe903e91de945e931e91ee9dc04c086dc2e5d965e96ae4fffb6c77e91ae49cf4a774b004ca8fd06f0d6f4b3d4bb981fa2f69bc52bd385098023ba437a41fa56ea5db0d7ec0be949e9f6098095dc2b7d30f52eccc7eee7e9d5a98d150007d29e9a794fea5d8867abbddef0dae4c568803d3a275d957a17ded96bc3d09ed66a2f760370028f48df4dbd8bed966aef786a6f5f056047edb7828fa5dec575cbbd26f96d0160a1f63982f696cede05b5429f4b774c00dc86a7a79b53ef425aa91fa50726003aae4cbd8b67e5daa79e01f80fed39f5bf4bbd0be669e88a0470eab531d8ca670b0ed99f278053edbda977813c8d1905e0d47a5bea5d184f734f4e00a74afbd770ef8278dabb255d9e004e85c7a6dec550bfacbdedd6f72d00e5dd25b53b82f62e84fa55df486ea50d94d5de51f495d4bb00ea3ff7ce045052bb8f4fefc2a7dfdea3134029ed4b6d7a173cdd763f49be530128c55345e379ea0828e34f52ef42a7e5dd3b016c5afb5e831b53ef22a7e5b52ff107d8b497a6de054ebbe7036bc0669d9dfc76b0bffc96006cd6f352efc2a6f17ca90eb039ed43683f48bd8b9ac6bb26016c4a7bbebb7741d3c9f37dccc0a6f89e83c3f5a7096013da5b4ddb6d9c7b17339dbc1b12c0263c3ef52e64da5f172580e9fd7dea5dc4b4bf9e9b00a6f7b3d4bb88697f7d32014ced92d4bb8069bfb5d7687c810e30b567a7de054cfbefb204302d6f375d2faf2300536bdf05dcbb7869ffbd3d014ca9ddaea277e1d261fa7c0298d205a977e1d261ba29014ca9dd89b377e1d2e13a2f014ce7b1a977d1d2e1ba30014ce749a977d1d2e1ba470298ce7352efa2a5c375ff04309d97a4de454b87eba109603aff33f52e5a3a5c8f4900d37969ea5db474b81e9600a6d3bec9ab77d1d2e17a400298ce9353efa2a5c375af04309dc7a5de454b87cb37a70153faddd4bb68e9709d9f00a67397d4bb68e930dd9c00a6e46ea7ebf6a50430ad6fa5dec54bfbef9d09605a1f4abd8b97f6df0b12c0b49e977a172fedbf76bb718069b5f7c5f72e5eda6fb7a4db278069b517967f917a1731edaf6b13c0f43e9a7a1731edaf172580e93d23f52e62da5ff74900d33b37b5e7b87b17329dbcf6d65e80cdf848ea5dcc74f23c5d046cca2353ef62a69377e704b019ed2d913f4bbd0b9ac6bb2e016c8eef58de7f972780cd3927fd3cf52e6cda3d37b30336cd17efefaff6ba0cc066dd21b5fbf6f72e705ade3712c0e65d917a17392def7712c0e6b5fb1b7d3df52e743a73ef4900653c28f52e76baedda8bf2ed693780523e907a173dfdf69e9f00ca691f56fbe7d4bbf0e93fd7be7d0ea0ac8bd34da97701d4affa763a3b0194f694d4bb08ea97b53bc5de33019c0a6f4fbd8ba1ce3aeb6909e0547977ea5d104f735e44064ea5f6f9844fa6de85f134f6bf13c0a9d56e80f7c5d4bb409ea6de97004ebdf69bc2d5a977a13c0dfdaf04c0af7967ea5d302bf79c044047fbd772efc259adf6598c3f4e00dc8676dfa31fa6de85b442ed35930b12000b9c973e957a17d42df786d45e33016047cf4d15be86f37be95109801338376df505e7f65ac10b92df0a00f6e8c1694b9f59f848ba28017020f74a9f48bd8bf00c5d95ee9a005849fb9ee1f7a77677d0de8579cd6e4c57a6bb25008ea43d3fffb0f4c1d4bb581faa5fa4f6dbc0650980c9b4b7abb671787d3ac4b7b35d975e9e1e90da37c001b0116d20ee9bfe28bd365d93dab791ddd607dfbe9bbe91da7740bf223d2edd23f9063380c2dad34db706000000000000000000000000000000000000c09eb53b7b5e921e99da7702bf39b5bb7f7e367d2b7de73ffa69eadd3154eb75736affbff87aba3e7d32fd756a77777d5e7a786a5fdce36eadc019b53b7dde3d3d3dbd2bb50b7eefc2a3edd76eebfdd6d46e077e970470d6b9e9bfa6f62d63ed9bbf7a170fd5effba90dc4e5c917fec029d29e32f883d4be24a67771d0e9eea6f4ded4c6c1f7434051eda981f6afc0f65c73ef4220fd663f4eaf4e1724a080f6b58fed85e0de035e5adad5e9b2046cd0a5a9bdd3a4f7e09646fb4cba5f0236e0aee9e3a9f76096f6557bebf13d1330a9f65901af1168cdfe2a7967124ca47de0e84ba9f780950eddbfa4fb26e0c8da6f05b7a4de03555ab377249f848623680fbc0fa7de03533a5637a4f6897760251726b796d0acb5df589f9580037b50ba31f51e88d24cbd210107d2fed5e5f5026da97f48e724608fae48bd079c347b5f4be727600f5e987a0f34692b7d37b927129c50fb7293de034cda5a46014ee089a9f7c092b69a518001ed7ef45e4056c5da279bef9080052e4ebec14c95fb72720f243883f6b596df4ebd079154a90f25e0367c2cf51e3c52c55e9e808ef67585bd078d54b9c724e0d7dc3ff51e2c52f5daeb65774e40b417d7fe35f51e2cd269e88be976094ebd7613b0de83443a4dbd2cc1a9d6be69aaf7e0904e63bea79953abfd8adc6efcd57b6048a7b1af264f1d712a3d3bf51e14d269aeddd9174e95768ff89fa6de03423acdb5771db9b505a7ca2b53efc120e9acb3de96e05468fffab929f51e08927ed92509ca7b63ea3d0024fdaa6b1294765e725b6b6959972628cb77234bcbfb608292dafbab7f907a075f52bfbb2428e751a977e025fdf6de94a09ceb52efc04bfaeddd9cda17474119edf6bebdc32ee9ccb54ff54319cf4bbd832ee9ccdd90a08c76d3aede4197b4ac8b136c9ea78ba493f78a049bf79cd43be09296f7dd049bf7b9d43be09276cb17e8b06967a7dec196b47bbe2b814dbb2cf50eb6a4ddfb7482cd7a7eea1d6c49bbd76e0c79fb049bf4f1d43bd892c66abf75c3e6b49bd9b5af03ec1d6a4963bd38c1e6f8fc81b4ffda6fddb0390f4abd032d69bc1f25d89ca7a4de819674b2ce49b029af4dbdc32ce964dd3dc1a67c38f50eb3a493f598049bf2cdd43bcc924ed69f27d894f64d4fbdc32ce964bd35c1a6f40eb2a493f7fe049bd13e5edf3bc8924ede67126c467b5b5cef204b3a795f4bb019e7a7de419674f27e9c6033dcb6423a6cb01917a6de2196b49f60332e4abd432c693fc166dc2df50eb1a4fd049bd1eeb5d23bc492f6136cc63d53ef104bda4fb019f74ebd432c693fc1665c9a7a8758d27e82cdb85fea1d6249fb0936e301a9778825ed27d80cdfa72c1d36d88c87a4de2196b49f60332e4fbd433c4b5f4c4bb88d77adfe392d71bbd4fbf333059bf1fba9778867e9bab48441a8954180237864ea1de259ba362d61106a6510e0081e9d7a8778963e9d963008b5320870047f907a8778963e91963008b5320870048f4fbd433c4b1f4b4b18845a1904388227a4de219ea50fa7250c42ad0c021cc11fa7de219ea50fa4250c42ad0c021cc15352ef10cfd27bd31206a15606018ee0e9a9778867e9dd690983502b830047f0ccd43bc4b3f4ceb48441a895418023f8d3d43bc4b374555ac220d4ca20c0113c2ff50ef12c5d99963008b53208700457a4de219ea537a4250c42ad0c021cc18b53ef10cfd25fa6250c42ad0c021cc1cb52ef10cfd26bd31206a15606018ee095a9778867e955690983502b830047d02eb8bd433c4b7f91963008b532087004ed2999de219ea597a6250c42ad0c021cc1eb53ef10cfd28bd21206a15606018ea0bdadb3778867e9f9690983502b830047f0e6d43bc4b3f467690983502b830047f0b6d43bc4b3f4ecb48441a8954180237847ea1de2597a465ac220d4ca20c011bc2bf50ef12c3d352d61106a6510e008fe2ef50ef12c3d312d61106a6510e008de977a877896da773e2f61106a6510e0083e987a8778961e9f963008b5320870041f4ebd433c4b8f4d4b18845a190438828fa7de219ea547a7250c42ad0c021cc12752ef10cfd223d21206a15606018ee0d3a9778867e961690983502b830047706dea1de259ba3c2d61106a6510e0083e977a8778961e9c963008b532087004d7a7de219ea507a6250c42ad0c021cc19753ef10cfd2fdd21206a15606018ee06ba9778867e9be690983502b830047d01e78bd433c4bf74e4b18845a190438826fa5de219ea57ba6250c42ad0c021cc17752ef10cfd2ddd31206a15606018ee007a9778867e96e690983502b830047f093d43bc4b374515ac220d4ca20c011fc2cf50ef12cdd352d61106a6510e0086e4ebd433c4b774e4b18845a19043882de019ea90bd21206a15606018ea0778067ea8e690983502b830047d03bc033757e5ac220d4ca20c0cab6f0603a2f2d61106a651060655b78309d9b963008b53208b0b22d3c98ce494b18845a190458d9162ea267a7250c42ad0c02acac5d6c7b0778a6da857e0983502b83002b6b4fc7f40ef04c1984d3994180956d6110da037e0983502b83002b6befe0e91de0993208a73383002b6beff1ef1de0995aca20d4ca20c0cadaa7807b0778a6963208b53208b0b2769fa0de019ea9a50c42ad0c02acec4ea9778067e9a6b49441a895418095b5ef1ae81de059ba312d65106a651060657749bd033c4b3f4e4b19845a190458d985a9778067e9fb692983502b83002bbb38f50ef02cfd6b5aca20d4ca20c0ca2e49bd033c4bdf4c4b19845a190458d9dd53ef00cfd20d692983502b83002bbb57ea1de059fa4a5aca20d4ca20c0caee937a077896ae4f4b19845a190458d97d53ef00cfd275692983502b83002bbb7fea1de059ba362d65106a651060650f4cbd033c4b9f4e4b19845a190458d98353ef00cfd227d25206a156060156f6bba9778067e963692983502b83002b7b68ea1de059ba3a2d65106a651060650f4fbd033c4bef4f4b19845a190458d9a352ef00cfd27bd25206a156060156f65f52ef00cfd2bbd35206a156060156f6b8d43bc0b3f4ceb49441a895418095fd61ea1de059ba2a2d65106a651060657f947a077896ae4c4b19845a190458d99352ef00cfd21bd25206a156060156f6d4d43bc0b3f4fab49441a8954180953d23f50ef02cbd262d65106a65106065cf4ebd033c4baf4a4b19845a190458d97353ef00cfd25fa4a50c42ad0c02acecf9a9778067e9a5692983502b83002b7b61ea1de0597a515aca20d4ca20c0ca5e927a077896da6f304b19845a190458d9cb53ef00cf527b8d632983502b83002bfb1fa9778067e959692983502b83002b7b75ea1de0597a7a5aca20d4ca20c0ca5e977a077896da27a9973208b53208b0b2bf4abd033c4b4f4c4b19845a190458d91b53ef00cfd213d25206a156060156f696d43bc0b3f4f8b49441a895418095b52fa0e91de0597a6c5aca20d4ca20c0cada5754f60ef02c3d3a2d65106a651060657f937a0778961e9e963208b53208b0b2f7a4de019ea587a6a50c42ad0c02acecfda9778067e9f2b49441a8954180957d28f50ef02c3d382d65106a651060651f4dbd033c4b0f4c4b19845a190458d935a9778067e97e692983502b83002bfb54ea1de059ba342d65106a651060659f49bd033c4bf74e4b19845a190458d96753ef00cfd23dd25206a156060156f6f9d43bc0b374f7b49441a8954180957d31f50ef02cdd2d2d65106a65106065ff947a0778962e4a4b19845a190458d90da9778067e9ae692983502b83002bfb66ea1de059ba735aca20d4ca20c0cabe9d7a077896ee94963208b53208b0b2efa5de019ea53ba6a50c42ad0c02acec87a9778067e90e692983502b83002bfb69ea1de0593a2f2d65106a65106065bf48bd033c4be7a6a50c42ad0c02acec96d43bc0b3744e5aca20d4ca20c0ca7a8777a6ce4e4b19845a19045859eff0ce54bbc82f65106a65106065bdc33b5306e1f4661060455b7820b5ffc6a50c42ad0c02acc82068e60c02ac680b17d05d18845a1904589141d0cc190458517b4b67eff0ced42e0c42ad0c02aca87de8ab777867e9a6b40b83502b83002b6ab785e81dde59ba31edc220d4ca20c08ada8de37a8777967e947661106a65106045edd6d2bdc33b4bedbb1a7661106a65106045e7a7dee19da5f66d6ebb3008b53208b0a2f66d64bdc33b4bedfb9e7761106a6510604517a4dee19da51bd22e0c42ad0c02ace8cea9777867e92b691706a15606015634fb6f08d7a65d18845a551984f6ad8430bdd95f54fe68da8541a8d5d241687a7f7e96767d73041cc5ec9f54fe3f691706a156bb0cc2cf52ef67ccd067136cc2cf53ef10cfd015691706a156bb0cc21752ef67ccd05b126cc275a9778867e891691706a156bb0cc2dfa6decf98a16726d884d7a7de219ea13ba55d18845aed3208cf49bd9f3143f74cb0098f4ebd437cec76bd6d4563106ab5cb20dc27f57ec6b16b4fc9b67741c126b43b9ede927a87f998bd26edca20d46a97416817dd9fa6decf3966ef48b0291f4abdc37ccc2e49bb3208b5da65109a2b53efe71cb3fb27d89407a5de613e56ff984618845aed3a08edb9fadecf39565f4db049ed3611bd437d8c7e278d3008b5da75109af6e9f6decf3a46edf539d8a407a6dea15ebb5d3f9dfceb0c42ad46066196179777bded0a4ce7dda977b8d7aa7d6566bb25f7288350ab914168da0bb9bd9fb756edbbc0ef9a60d3da05b5dd72ba77c8d7e8f7d24918845a8d0e423b07df48bd9fb946ff3d4109ed0ea8ed3300bd837ec89e954eca20d46a74109a0bd34f52efe71eb2d72528a5fdbafb9dd43bf087a87dca741f0c42ad4e3208cd3dd29a9f4df8cb04259d970efd8e8df62fb887a47d3108b53ae92034ed4ba0be9e7a3f7f5fdd9c9e9ca0bce7a776e07b0f849374756aa3b34f06a156fb1884a69d8b37a7dedf71d2da5d56dbd353706ab477fefc4dea3d2076edfad4dee27a0806a156fb1a845bdd2bfdffd4fbbb76edfbe909094eadf60d6bed3b0a76fd15bc3d35f4a6d41e9087547110dad72fb611bdadbe9b7a7f76ebed7b106ed5cee1dbd3c897ea5c93da6dd9ddb00e7e4dbb35f523527b4ae98de97da93d58da7d91ae4a2f4ded5f5017a7b5541c84afa533795aeafdd9ad77a841b855bba85f96fe2cfd756ae3dade4c716bed2dd8ed5cbf2c5d9eda8d20818d3008b53af420008519845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a89541008619845a1904609841a895410086551c842fa4337942eafdd9adf7e50430e476a97761d9729f4a67f2f0d4fbb35bef1f13c0b0de8565cb7d309dc9fd53efcf6ebd8f27806137a6dec565ab5d99cee4a2d4fbb35befdd0960d8e753efe2b2d59e9bcea4e26b27ad97278061ed5f95bd8bcb56fbfdb4c4b753efcf6fb93f4c00c35e967a1797ad76615ae26f53efcf6fb94b13c0b0cb53efe2b2c57e9a96aaf8d6d3f65418c0b03ba4dec5658bbd2f2d7541eafd8cadd65e0b0238b17f49bd8bccd66affeadfc50da9f773b6d82b12c089bd24f52e325bea96744edac5b352ef676db14b12c08955785ffe920fa4fda6f352ef676dadaf2780bdb93ef52e365be90169c43b52efe76da93f49007bf3c8d4bbd86ca1ebd2a8adbfb8fce3e4dd45c0de7d33f52e3ab3f7e074126f49bd9fbb855e9000f6eea1a977d199b9bf4f277576fa5eeafdfc99fb566a77ac0538888fa5dec567c6da07d1da0bc3fbb0c5316c1f2a043898f3537b5eba77019aad7d5f105f957a7fcf8c5d95000eae3d27dfbb08cd54bb07d3217c24f5febe996a2fa27baa0858cdb353ef6234436f4e87d22eb49f4cbdbf7786da0bfffb7a9a0c60b117a7de45e998adf154491b85ff9b7a7fff316bb7ec6e4fe9011cc5d352bb2d44ef02b576ed161b6b69a3d07e13e9fd771ca3f63451bb1121c051b5ef20fe61ea5da8d6e827e911e9189e987e9e7aff5d6bd53e4ded3503601ae7a663bce07a4d3af6bf8cef943e937aff7d87acbddbeb5843087046ed16176b7ca2f92be9a49f40deb7df4b5f4dbdffde7d76737a5ddaf5eead00ab6b4f5f3c3e1de20bfa3f91661b82dfd4fefb0ef101bef61bc12bd31d13c0e65c9cae48ed5ff4bd8bdc923e979e99b676216ceff8796afa741a7de1bdbd36f3a6f490e47502a08cf61447bb0df573d21b53fbd77ebbadf6adb5e7e1af4eaf4fcf48edffb6dd47a88276c7d1f625f74f49af4eedfb193e957efd7fffb5a9bd40fcc2f4f0e4370100e058ce3aebdf0154c162660e5bf1d30000000049454e44ae426082");
        }

        #endregion
    }
}
