$input v_color0, v_normal, v_view

#include "common.sh"
uniform vec4  u_Kd;
uniform vec4  u_Ka;

vec2 blinn(vec3 _lightDir, vec3 _normal, vec3 _viewDir)
{
	float ndotl = dot(_normal, _lightDir);
	vec3 reflected = _lightDir - 2.0*ndotl*_normal; // reflect(_lightDir, _normal);
	float rdotv = dot(reflected, _viewDir);
	return vec2(ndotl, rdotv);
}
/*
float fresnel(float _ndotl, float _bias, float _pow)
{
	float facing = (1.0 - _ndotl);
	return max(_bias + (1.0 - _bias) * pow(facing, _pow), 0.0);
}

vec4 lit(float _ndotl, float _rdotv, float _m)
{
	float diff = max(0.0, _ndotl);
	float spec = step(0.0, _ndotl) * max(0.0, _rdotv * _m);
	return vec4(1.0, diff, spec, 1.0);
}
*/


vec3 phong(vec3 fragPos, vec3 normal,vec3 viewport, vec4 light, vec3 light_color, float specular_factor, float shininess) {
            vec3 light_normal = normalize(light.xyz-fragPos*light.w);
            vec3 viewDir = normalize(viewport - fragPos);
            //vec3 reflect = reflect(-light_normal,normal);
            //float spec_power = pow(max(dot(reflect,viewDir),0.0),specular_factor)*shininess;


            float d = dot(normal,light_normal);
            if (d > 0) {
                //vec3 specular_light = light_color*spec_power;
                vec3 diffuse_light = light_color*d;
                return (diffuse_light);
            } else {
                return vec3(0,0,0);
            }
        }


void main()
{
	vec3 lightDir = normalize(vec3(0.2, 0.8, 0.2));
	vec3 normal = normalize(v_normal);
	vec3 view = normalize(v_view);
	vec2 bln = blinn(lightDir, normal, view);
	vec4 lc = lit(bln.x, bln.y, 1.0);
	//float fres = fresnel(bln.x, 0.2, 5.0);

	//float index = ( (sin(v_pos.x*3.0+u_time.x)*0.3+0.7)
	//			+ (  cos(v_pos.y*3.0+u_time.x)*0.4+0.6)
	//			+ (  cos(v_pos.z*3.0+u_time.x)*0.2+0.8)
	//			)*M_PI;

	/*
	vec3 color = vec3(sin(index*8.0)*0.4 + 0.6
					, sin(index*4.0)*0.4 + 0.6
					, sin(index*2.0)*0.4 + 0.6
					) * v_color0.xyz;
*/
	vec3 color = u_Kd.rgb;
	
	color = phong(view,normal,vec3(0,0,0),vec4(0.2,0.8,0.1,1),vec3(1,1,1),0,0);

	gl_FragColor.xyz = max(color,u_Kd.rgb);
	gl_FragColor.w = 1.0;
	//gl_FragColor = vec4(u_Kd.rgb,1);
}
