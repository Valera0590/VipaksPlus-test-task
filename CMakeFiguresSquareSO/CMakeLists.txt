# CMakeList.txt: файл проекта CMake верхнего уровня; проведите глобальную конфигурацию
# и включите сюда подпроекты.
#
cmake_minimum_required (VERSION 3.8)

project ("CMakeFiguresSquareSO")

set (CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++1y -Wall")

#Создание динамической библиотеки
add_library(${PROJECT_NAME} SHARED CMakeFiguresSquareSO/CMakeFiguresSquareSO.cpp)
