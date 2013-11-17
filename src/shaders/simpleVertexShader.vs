#version 330

//Input for every vertex
layout(location=0) in vec3 in_Position;
layout(location=1) in vec3 in_Normal;

//Output
out vec4 normal;
out vec4 position;

//Input for all vertices
uniform mat4 ModelViewMatrix;
uniform mat4 ProjectionMatrix;
uniform mat4 NormalMatrix;



void main(void)
{
	//Calculate the final vertex position in clipping space
	gl_Position = (ProjectionMatrix * ModelViewMatrix) * vec4(in_Position,1.0);
    //Transform the normal and pass it to the fragment shader
	normal      = normalize(NormalMatrix * vec4(in_Normal, 0.0));
    //Tansform vertex position to eye space
    position = ModelViewMatrix*vec4(in_Position,1.0);
}
