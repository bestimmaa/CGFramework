#version 330

uniform sampler2D colorMap;
uniform sampler2D normalMap;
uniform sampler2D glossMap;

in  vec4 normal;
in  vec4 vertexPosition;
in  vec3 vertexPosition_worldspace;
in  vec4 eye_direction_cameraspace;
in  vec4 eye_direction_tangentspace;
in  vec4 light_direction_cameraspace;
in  vec4 light_direction_tangentspace;
in  vec3 light_position_worldspace;
in  vec2 texcoord;
in vec3 debug;

out vec4 out_Color;



void main(void)
{
    vec3 LightColor = vec3(1,1,1);
	float LightPower = 500;
    
    vec3 MaterialDiffuseColor = texture( colorMap, texcoord ).rgb;
	vec3 MaterialAmbientColor = vec3(0.1,0.1,0.1) * MaterialDiffuseColor;
	vec3 MaterialSpecularColor = texture( glossMap, texcoord ).rgb * 0.3;
    
    vec3 TextureNormal_tangentspace = normalize(texture( normalMap, vec2(texcoord.x,texcoord.y) ).rgb*2.0 - 1.0);
    float distance = length( light_position_worldspace - vertexPosition_worldspace );
    
    vec3 n = TextureNormal_tangentspace;
    vec3 l = normalize(light_direction_tangentspace.xyz);
    
    float cosTheta = clamp( dot( n,l ), 0,1 );
	vec3 E = normalize(eye_direction_tangentspace.xyz);
    vec3 R = reflect(-l,n);
    
    float cosAlpha = clamp( dot( E,R ), 0,1 );
    
    vec3 color;
    
    color   += MaterialAmbientColor;
    // Diffuse : "color" of the object
    color  += MaterialDiffuseColor * LightColor * LightPower * cosTheta / (distance*distance);
    // Specular : reflective highlight, like a mirror
    color  += MaterialSpecularColor * LightColor * LightPower * pow(cosAlpha,5) / (distance*distance);
    
    out_Color = vec4(color ,1);

}
