

export default class Fetcher{
    static getUsers = () => Getter('/api/home');


}


export function Getter(url, method = 'GET'){
    const response =   fetch(url, method);
    const data =   response.json();
    return Promise.resolve(data);   
}