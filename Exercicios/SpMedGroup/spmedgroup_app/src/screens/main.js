import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';


import Consultas from './Consultas';
import Perfil from './Perfil';


const bottomTab = createBottomTabNavigator();

export default class Main extends Component {

  render() {
    return (
      <View style={styles.main}>
        <bottomTab.Navigator
          initialRouteName='Consultas'
          tabBarOptions={{
            showLabel: false,
            showIcon: true,
            activeBackgroundColor: 'rgb(45, 45, 255)',
            inactiveBackgroundColor: 'rgb(91, 91, 249)',
            activeTintColor: '#FFF',
            inactiveTintColor: '#FFF',
            style: { height: 50 }
          }}
          screenOptions={({ route }) => ({
            tabBarIcon: () => {
              if (route.name === 'Consultas') {
                return (
                  <Image
                    source={require('../../assets/img/calendar.png')}
                    style={styles.tabBarIcon}
                  />
                )
              }

              if (route.name === 'Perfil') {
                return (
                  <Image
                    source={require('../../assets/img/profile.png')}
                    style={styles.tabBarIcon}
                  />
                )
              }
            }
          })}
        >
          <bottomTab.Screen name='Consultas' component={Consultas} />
          <bottomTab.Screen name='Perfil' component={Perfil} />
        </bottomTab.Navigator>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },

  tabBarIcon: {
    width: 26,
    height: 26
  }
});
