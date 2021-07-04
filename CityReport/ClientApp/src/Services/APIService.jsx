import http from "./httpService";

const citiesUrl ="api/CityReport/GetAvailableCities";
const timeZoneUrl ="api/CityReport/GetTimeZoneBy?city=";
const currentWeatherUrl ="api/CityReport/GetCurrentWeatherBy?city=";
const  astronomyUrl ="api/CityReport/GetAstronomyBy?city=";

export async function getAvailableCities(){
    const{data: response} = await http.get(citiesUrl)
    return response;
}

export async function getTimeZoneBy(city){
    const {data : response} = await http.get(timeZoneUrl+city);
    return response;
}

export async function getCurrentWeatherBy(city){
    const {data: response}= await http.get(currentWeatherUrl+city);
    return response;
}

export async function getAstronomyBy(city){
    const {data: response} = await http.get(astronomyUrl+city);
    return response;
}