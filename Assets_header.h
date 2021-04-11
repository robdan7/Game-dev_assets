#pragma once
#include <string>

/**
 * Det är typ så här jag tänker mig att headerfilen kan se ut
 */
namespace Orvox {
    namespace Runtime_assets {

        /**
         * Bgfx kompilatorn importerar inte .mtl filer från en .obj mesh, så det vi borde göra är att skapa en egen
         * mtl laddar-grej. Det är ganska enkelt om man sparar parametrarna
         * i samma format som en vanlig struct och när man sen läser in material-filen så har filen samma format som
         * structen. Byte är byte så det spelar ingen roll om de kommer från disk eller ram.
         */
        namespace Material_properties {
            const char Some_material[] = "Material/Some_material.mtl";
        }

        namespace Mesh {
            const char Sword[] = "Mesh/Sword.bin";
            const char Waffle[] = "Runtime/Mesh/Waffle.bin";
        }

        namespace Shader {
            const char my_vs_shader[] = "Shader/my_vs_shader.bin";
            const char my_fs_shader[] = "Shader/my_fs_shader.bin";
        }

        /**
         * Här börjar det intressanta. Vi kan gruppera ihop meshes med materialegenskaper. :D
         */
        namespace Model_asset {
            using namespace Orvox::Runtime_assets;
            struct Model {
                const char* m_mesh;
                const char* m_material;
            };
            const Model Sword_model{Mesh::Sword, Material_properties::Some_material};
        }
    }
}