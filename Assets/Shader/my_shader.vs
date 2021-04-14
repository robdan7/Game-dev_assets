$input a_position, a_color0,a_normal

$output v_color0,v_normal, v_view

#include "common.sh"

void main() {

	vec3 pos = a_position;
	vec3 normal = a_normal.xyz*2.0 - 1.0;	

	//gl_Position = mul(u_modelViewProj, vec4(a_position, 1.0) );
	//v_pos = gl_Position.xyz;
	v_view = mul(u_modelView, vec4(pos, 1.0) ).xyz;

	v_normal = mul(u_modelView, vec4(normal, 0.0) ).xyz;

	//float len = length(displacement)*0.4+0.6;

	v_color0 = a_color0;
	//v_pos = a_position;
	gl_Position = mul(u_modelViewProj, vec4(a_position, 1.0) );
}