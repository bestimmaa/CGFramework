#version 330

in  vec4 normal;
in  vec4 position;

out vec4 out_Color;



void main(void)
{
    vec4 baseColor = vec4(59/255.0,61/255.0,117/255.0,0);
    
    // we are in eye space here, the eye is at 0,0,0!
    vec3 lightPosition = vec3(11.0,10.0,0.0);
    vec4 AmbientColor = vec4(0.0, 0.0, 0.0, 1.0);
    vec4 DiffuseColor = vec4(0.0, 0.0, 0.0, 1.0);
    
    vec3 vertexToLightVector =  normalize(lightPosition - position.xyz);
    vec3 normalizedNormal = normalize(normal.xyz);
    vec3 eyeToVertexVector = normalize(-reflect(vertexToLightVector,normalizedNormal));
    vec3 eye = normalize(-vec3(position.xyz));
    
    int phongReflectionRadius = 90; // radius of the phong reflections

    float ambientFactor = 0.2;
    vec4 ambientTerm = ambientFactor*baseColor;

    float diffuseFactor = max(dot(normalizedNormal,vertexToLightVector),0.0);
    vec4 diffuseTerm = diffuseFactor*baseColor;
    
    
    float shininess = 5;
    float specularFactor = pow(max(dot(eyeToVertexVector,eye),0.0),shininess);
    vec4 specularTerm = specularFactor * baseColor;
    
    out_Color = ambientTerm+diffuseTerm+specularTerm;
    
}
